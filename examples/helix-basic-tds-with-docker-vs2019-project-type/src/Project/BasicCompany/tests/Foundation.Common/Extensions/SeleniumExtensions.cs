using BasicCompany.Foundation.Common.UITests.Infrastructure;
using Microsoft.Edge.SeleniumTools;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace BasicCompany.Foundation.Common.UITests.Extensions
{
  public static class SeleniumExtensions
  {

    public static IWebDriver SeleniumDriver(this FeatureContext featureContext, IConfiguration configuration)
    {
      if (featureContext == null)
        throw new ArgumentNullException(nameof(featureContext));

      if (configuration == null)
        throw new ArgumentNullException(nameof(configuration));

      if (featureContext.ContainsKey(typeof(IWebDriver).FullName ?? throw new InvalidOperationException()))
        return featureContext.Get<IWebDriver>();

      return CreateSeleniumDriver(featureContext, configuration);
    }

    public static IWebElement WaitUntilElementIsPresent(this IWebDriver driver, By selector, int timeoutInSeconds)
    {

      WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
      wait.Until<IWebElement>((d) => d.FindElement(selector));

      return driver.FindElement(selector);
    }


    private static IWebDriver CreateSeleniumDriver(this SpecFlowContext specFlowContext, IConfiguration configuration)
    {
      System.Enum.TryParse(configuration[Constants.EnvironmentVariableKeys.Browser], true, out BrowserTypes browser);

      switch (browser)
      {

        case BrowserTypes.Edge:
          EdgeOptions egdeOptions = new EdgeOptions
          {
            PageLoadStrategy = PageLoadStrategy.Normal,
            UseChromium = true
          };

          EdgeDriverService edgeDriverService = EdgeDriverService.CreateChromiumService(configuration[Constants.EnvironmentVariableKeys.EdgeWebDriver]);

          specFlowContext.Set((IWebDriver)new EdgeDriver(edgeDriverService, egdeOptions));
          break;

        case BrowserTypes.Firefox:
          specFlowContext.Set((IWebDriver)new FirefoxDriver());
          break;

        case BrowserTypes.InternetExplorer:

          InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions()
          {
            BrowserVersion = configuration[Constants.EnvironmentVariableKeys.InternetExplorerVersion],
            IgnoreZoomLevel = true
          }; 

          specFlowContext.Set((IWebDriver)new InternetExplorerDriver(internetExplorerOptions));
          break;

        case BrowserTypes.Safari:
          SafariDriverService safariDriverService = SafariDriverService.CreateDefaultService();
          SafariOptions safariOptions = new SafariOptions();
          safariOptions.PageLoadStrategy = PageLoadStrategy.Normal;
          specFlowContext.Set((IWebDriver)new SafariDriver(safariDriverService));
          break;

        default:
          {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.SuppressInitialDiagnosticInformation = true;
            specFlowContext.Set((IWebDriver)new ChromeDriver(chromeDriverService));
          }
          break;
      }

      return specFlowContext.Get<IWebDriver>();
    }
  }
}

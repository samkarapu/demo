using BasicCompany.Foundation.Common.UITests.Infrastructure;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
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
          var options = new Microsoft.Edge.SeleniumTools.EdgeOptions
          {
            PageLoadStrategy = PageLoadStrategy.Normal,
            UseChromium = true,
            BinaryLocation = configuration[Constants.EnvironmentVariableKeys.EdgeBinaryLocation],
          };

          //var options = new Microsoft.Edge.SeleniumTools.EdgeOptions
          //{
          //  PageLoadStrategy = PageLoadStrategy.Normal,

          //};

          var service = Microsoft.Edge.SeleniumTools.EdgeDriverService.CreateChromiumService(configuration[Constants.EnvironmentVariableKeys.EdgeWebDriver]);

          //System.setProperty("webdriver.edge.driver", "C:\\Program Files (x86)\\Microsoft Web Driver\\MicrosoftWebDriver.exe"); //put actual location

          //specFlowContext.Set((IWebDriver)new Microsoft.Edge.SeleniumTools.EdgeDriver(@"C:\Slask\sss", options));

          specFlowContext.Set((IWebDriver)new Microsoft.Edge.SeleniumTools.EdgeDriver(service, options));
          break;

        case BrowserTypes.Firefox:
          specFlowContext.Set((IWebDriver)new FirefoxDriver());
          break;

        case BrowserTypes.InternetExplorer:
          specFlowContext.Set((IWebDriver)new InternetExplorerDriver());
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

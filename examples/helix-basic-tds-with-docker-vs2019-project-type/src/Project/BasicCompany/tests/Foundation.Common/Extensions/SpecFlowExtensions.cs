using BasicCompany.Foundation.Common.UITests.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using TechTalk.SpecFlow;

namespace BasicCompany.Foundation.Common.UITests.Extensions
{
  public static class SpecFlowExtensions
  {
    public static IWebDriver SeleniumDriver(this FeatureContext featureContext, BrowserTypes browser)
    {
      if (featureContext == null)
        throw new ArgumentNullException(nameof(featureContext));

      if (featureContext.ContainsKey(typeof(IWebDriver).FullName ?? throw new InvalidOperationException()))
        return featureContext.Get<IWebDriver>();

      //System.Enum.TryParse(BaseSettings.BrowserType, true, out BrowserTypes browserType);

      return CreateSeleniumDriver(featureContext, browser);
    }

    private static IWebDriver CreateSeleniumDriver(this SpecFlowContext specFlowContext, BrowserTypes browser)
    {
      switch (browser)
      {

        case BrowserTypes.Edge:
          var options = new EdgeOptions
          {
            PageLoadStrategy = PageLoadStrategy.Normal
          };

          specFlowContext.Set((IWebDriver)new EdgeDriver(options));
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

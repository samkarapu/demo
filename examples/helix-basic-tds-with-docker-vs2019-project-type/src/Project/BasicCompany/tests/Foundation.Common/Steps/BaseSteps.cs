using BasicCompany.Foundation.Common.UITests.Extensions;
using BasicCompany.Foundation.Common.UITests.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace BasicCompany.Foundation.Common.UITests.Steps
{

  public class BaseSteps : TechTalk.SpecFlow.Steps
  {
    protected readonly ScenarioContext _scenarioContext;
    protected readonly FeatureContext _featureContext;
    protected static IWebDriver _driver;
    protected readonly WebDriverWait _wait;
    protected readonly IConfiguration _configuration;


    protected BaseSteps(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
      _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
      _featureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));
      _driver = _featureContext.SeleniumDriver(BrowserTypes.Chrome);
      _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
      _configuration = scenarioContext.ScenarioContainer.Resolve<IConfiguration>();

    }



    protected void GoToPage(string url)
    {
      Console.WriteLine($"Navigates to url: {url}");

      //Verify  
      if (_driver.Url != url)
        _driver.Navigate().GoToUrl(url);

      _driver.Manage().Window.Maximize();

    }


  }
}

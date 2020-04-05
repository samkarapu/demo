using BasicCompany.Foundation.Common.UITests.Services;
using OpenQA.Selenium;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;


namespace BasicCompany.Foundation.Common.UITests.Infrastructure
{

  [Binding]
  public  class ScenarioFeatureHooks
  {
    private readonly ScenarioContext _scenarioContext;

    private static IConfiguration config;

    public ScenarioFeatureHooks(ScenarioContext scenarioContext)
    {
      _scenarioContext = scenarioContext;
    }

    private static ProcessService ProcessService => new ProcessService();

    protected static void DisposeDriver(FeatureContext featureContext)
    {

      var driver = featureContext.Get<IWebDriver>();

      if (driver == null)
        return;

      driver.Quit();
      driver.Dispose();

      if (!System.Diagnostics.Debugger.IsAttached)
        return;

      if (driver.GetType().Name != "ChromeDriver")
        return;

      try
      {
        ProcessService.KillProcessAndChildren("chromedriver.exe");
      }
      catch
      {
        // ignored
      }
    }


    [BeforeScenario()]
    public void CreateConfig()
    {

      if (config == null)
      {

        config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("specflow.json", optional: false, reloadOnChange: true) 
          .AddEnvironmentVariables() 
          .Build();
      }

      _scenarioContext.ScenarioContainer.RegisterInstanceAs<IConfiguration>(config);

    }

    [AfterScenario()]
    public void AfterScenario()
    {
      Console.WriteLine("Finished " + _scenarioContext.ScenarioInfo.Title);
    }

    [BeforeFeature()]
    public static void BeforeFeature(FeatureContext featureContext)
    {
      Console.WriteLine("Starting " + featureContext.FeatureInfo.Title);
    }

    
    [AfterFeature()]
    public static void TearDownTests(FeatureContext featureContext)
    {
      DisposeDriver(featureContext);
    }
  }
}

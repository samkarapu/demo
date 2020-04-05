using BasicCompany.Foundation.Common.UITests.Services;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace BasicCompany.Foundation.Common.UITests.Infrastructure
{

  [Binding]
  public  class DisposeDriverBinding
  {
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

    
    [AfterFeature()]
    public static void TearDownTests(FeatureContext featureContext)
    {
      DisposeDriver(featureContext);
    }
  }
}

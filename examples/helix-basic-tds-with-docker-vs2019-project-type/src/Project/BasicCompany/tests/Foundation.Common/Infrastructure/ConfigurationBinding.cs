using Microsoft.Extensions.Configuration;
using System.IO;
using TechTalk.SpecFlow;


namespace BasicCompany.Foundation.Common.UITests.Infrastructure
{

  [Binding]
  public  class ConfigurationBinding
  {
    private readonly ScenarioContext _scenarioContext;

    private static IConfiguration config;

    public ConfigurationBinding(ScenarioContext scenarioContext)
    {
      _scenarioContext = scenarioContext;
    }

  

    [BeforeScenario()]
    public void RegisterConfiguration()
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

    //[AfterScenario()]
    //public void AfterScenario()
    //{
    //  Console.WriteLine("Finished " + _scenarioContext.ScenarioInfo.Title);
    //}

    //[BeforeFeature()]
    //public static void BeforeFeature(FeatureContext featureContext)
    //{
    //  Console.WriteLine("Starting " + featureContext.FeatureInfo.Title);
    //}

  }
}

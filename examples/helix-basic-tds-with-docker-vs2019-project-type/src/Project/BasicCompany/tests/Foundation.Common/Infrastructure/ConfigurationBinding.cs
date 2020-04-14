using Microsoft.Extensions.Configuration;
using System.IO;
using TechTalk.SpecFlow;


namespace BasicCompany.Foundation.Common.UITests.Infrastructure
{

  [Binding]
  public class ConfigurationBinding
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
        config = GetConfiguration();
      
      _scenarioContext.ScenarioContainer.RegisterInstanceAs<IConfiguration>(config);

    }

    private IConfiguration GetConfiguration()
    {

      var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory());

#if DEBUG
      configuration.AddEnvironmentVariables();
      configuration.AddJsonFile("specflow.json", optional: false, reloadOnChange: true);
#else
      configuration.AddJsonFile("specflow.json", optional: false, reloadOnChange: true);
     configuration.AddEnvironmentVariables();
#endif

      ////If debug then we will use specflow.json variables
      //if (System.Diagnostics.Debugger.IsAttached)
      //{
      //  configuration.AddEnvironmentVariables();
      //  configuration.AddJsonFile("specflow.json", optional: false, reloadOnChange: true);
      //}
      //else
      //{
      //  configuration.AddJsonFile("specflow.json", optional: false, reloadOnChange: true);
      //  configuration.AddEnvironmentVariables();
      //}

      return configuration.Build();

    

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

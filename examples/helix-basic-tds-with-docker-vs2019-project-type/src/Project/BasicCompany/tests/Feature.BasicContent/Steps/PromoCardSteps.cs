using System;
using BasicCompany.Foundation.Common.UITests.Steps;
using TechTalk.SpecFlow;

namespace BasicCompany.Feature.BasicContent.UITests.Steps
{
  [Binding]
  public class PromoCardSteps : BaseSteps
  {

    protected PromoCardSteps(ScenarioContext scenarioContext, FeatureContext featureContext) : base(scenarioContext, featureContext)
    {
    }


    [Given(@"I am a website visitor")]
    public void GivenIAmAWebsiteVisitor()
    {
      base.GoToPage("https://google.se");
    }

   
    [When(@"I navigate to the Home page")]
    public void WhenINavigateToTheHomePage()
    {
      ScenarioContext.Current.Pending();
    }

    [Then(@"I expect to see promo cards")]
    public void ThenIExpectToSeePromoCards()
    {
      ScenarioContext.Current.Pending();
    }

    [AfterFeature()]
    public static void TearDownTests()
    {
      BaseSteps.DisposeDriver();
    }

  }
}

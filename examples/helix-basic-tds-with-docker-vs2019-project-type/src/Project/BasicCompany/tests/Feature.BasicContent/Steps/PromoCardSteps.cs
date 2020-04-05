using BasicCompany.Foundation.Common.UITests.Steps;
using FluentAssertions;
using OpenQA.Selenium;
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
      var b = _configuration;

   
      base.GoToPage(_configuration["BaseUrl"]);
    }

   
    [When(@"I navigate to the Home page")]
    public void WhenINavigateToTheHomePage()
    {
      var element = _driver.FindElement(By.ClassName("content"));
      element.Should().NotBeNull();
    }

    [Then(@"I expect to see promo cards")]
    public void ThenIExpectToSeePromoCards()
    {
      var element = _driver.FindElement(By.ClassName("content"));
      element.Should().NotBeNull();
    }

    //[AfterFeature()]
    //public static void TearDownTests()
    //{
    //  BaseSteps.DisposeDriver();
    //}

  }
}

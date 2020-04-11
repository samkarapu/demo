using BasicCompany.Foundation.Common.UITests;
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
      base.SetUrl(_configuration[Constants.EnvironmentVariableKeys.BaseUrl]);
    }

   
    [When(@"I navigate to the Home page")]
    public void WhenINavigateToTheHomePage()
    {
      _driver.Navigate().GoToUrl($"{_configuration[Constants.EnvironmentVariableKeys.BaseUrl]}/en");
      var element = _driver.FindElement(By.CssSelector("a.navbar-item.is-tab.is-active"));
      element.Text.Trim().Should().Be("Home");
    }

    [Then(@"I expect to see promo cards")]
    public void ThenIExpectToSeePromoCards()
    {
      var promoCards = _driver.FindElements(By.CssSelector("div.column.promo-column.graphQlPromoCard"));
      promoCards.Count.Should().Be(5);
    }


  }
}

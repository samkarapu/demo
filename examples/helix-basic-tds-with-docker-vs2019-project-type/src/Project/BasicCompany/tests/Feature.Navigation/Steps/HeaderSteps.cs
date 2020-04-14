using BasicCompany.Foundation.Common.UITests.Steps;
using OpenQA.Selenium;
using FluentAssertions;
using System.Linq;
using TechTalk.SpecFlow;
using BasicCompany.Foundation.Common.UITests;
using BasicCompany.Foundation.Common.UITests.Extensions;

namespace BasicCompany.Feature.Navigation.UITests.Steps
{
  [Binding]
  public class HeaderSteps : BaseSteps
  {


    public HeaderSteps(ScenarioContext scenarioContext, FeatureContext featureContext) : base(scenarioContext, featureContext)
    {
    }

    [Given(@"I am a website visitor")]
    public void GivenIAmAWebsiteVisitor()
    {
      base.SetUrl(_configuration[Constants.EnvironmentVariableKeys.BaseUrl]);
    }

    [When(@"I select '(.*)' in the primary navigation")]
    public void WhenISelectInThePrimaryNavigation(string naveItem)
    {
      var elements = _driver.FindElements(By.CssSelector("a.navbar-item.is-tab"));

      var navElement = elements.FirstOrDefault(el => el.Text.Trim().Equals(naveItem));
      navElement.Click();
      Wait(2);
    }

    [Then(@"I expect to be directed to the '(.*)' page")]
    public void ThenIExpectToBeDirectedToThePage(string naveItem)
    {
      var element = _driver.WaitUntilElementIsPresent(By.CssSelector("a.navbar-item.is-tab.is-active"), 5);
      element.Text.Trim().Should().Be(naveItem);
    }


  }
}

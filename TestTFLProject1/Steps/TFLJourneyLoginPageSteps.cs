using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestTFLProject1.Pages;

namespace TestTFLProject1.Steps
{
    [Binding]
    public class TFLJourneyLoginPageSteps
    {
        LoginPage loginPage = null;
        ResultsPage resultsPage = null;

        [Given(@"Navigate to TFL Journey Planner")]
        public void GivenLoginToJourneyPlanner()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(webDriver);
            resultsPage = new ResultsPage(webDriver);
            if (loginPage.IsCookieexits())
            {
                loginPage.ClickAcceptCookie();
                loginPage.ClickDoneonCookie();
            }
        }
        [Given(@"I input journey From and to details")]
        public void GivenIInputJorunyFromAndToDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.PlanJourney((string)data.From, (string)data.To);


        }
        [When(@"I Click on the Plan Journey Page")]
        public void WhenIClickOnThePlanJourneyPage()
        {
            loginPage.ClickPlanJourney();
        }

        [Then(@"I can see the results")]
        public void ThenICanSeeTheResults()
        {
            loginPage.IsPageexits();
        }


        [When(@"user plans a journey from London Victoria to London Bridge")]
        public void WhenUserPlansAJourneyFromLondonVictoriaToLondonBridge()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user should be presented with the Journey Results page with the correct summary")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithTheCorrectSummary(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            resultsPage.CheckJourneyResults((string)data.From, (string)data.To);

        }
     

        [Then(@"user should be presented with the Journey Results page with an error message")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithAnErrorMessage()
        {
            resultsPage.IsErrorplanJourneyInvalidErrorexits();
        }

        [Then(@"user sees an error message telling them that the To field is required")]
        public void ThenUserSeesAnErrorMessageTellingThemThatTheToFieldIsRequired()
        {
            loginPage.IsPageplanJourneyInvalidErrorexits();
        }

        [When(@"I edit a journey and input the following station")]
        public void WhenIEditAJourneyAndInputTheFollowingStation(Table table)
        {
            resultsPage.ClickEditJourney();
            dynamic data = table.CreateDynamicInstance();
            resultsPage.EditJourneyFromTo((string)data.From, (string)data.To);
            resultsPage.ClickupdateJourney();
        }

        [When(@"user click on the link to go back to Plan a journey page")]
        public void WhenUserClickOnTheLinkToGoBackToPlanAJourneyPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            resultsPage.ClickPlanAJourneyLink();
        }

        [Then(@"user will click on Recents link button")]
        public void ThenUserWillClickOnRecentsLinkButton()
        {
            loginPage.ClickRecent();
        }

        [Then(@"user should see recent journeys")]
        public void ThenUserShouldSeeRecentJourneys()
        {
            loginPage.CheckNoRecentResultMessage();
        }
    }
}

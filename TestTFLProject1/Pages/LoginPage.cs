using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestTFLProject1.Pages
{
    class LoginPage
    {
        public IWebDriver WebDriver{ get; }
        public LoginPage(IWebDriver webdriver) 
        { 
            
            WebDriver = webdriver;

        }
        public IWebElement journeyFrom => WebDriver.FindElement(By.Id("InputFrom"));
        public IWebElement journeyTo => WebDriver.FindElement(By.Id("InputTo"));
        public IWebElement planJourney => WebDriver.FindElement(By.Id("plan-journey-button"));
        public IWebElement planJourneyCookieAccept => WebDriver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        public IWebElement planJourneyCookieDone => WebDriver.FindElement(By.XPath("//button/strong[contains(.,'Done')]"));
        public IWebElement planJourneyInvalidError => WebDriver.FindElement(By.XPath("//span[@id='InputFrom-error' and contains(.,'The From field is required.')]"));

        public IWebElement recentLink => WebDriver.FindElement(By.XPath("//a[contains(.,'Recents')]"));

        public void ClickPlanJourney() => planJourney.Click();
        public void ClickAcceptCookie() => planJourneyCookieAccept.Click();
        public void ClickDoneonCookie() => planJourneyCookieDone.Click();
        public void ClickRecent() => recentLink.Click();

        public void CheckNoRecentResultMessage()
        {
            WebDriver.FindElement(By.XPath("//div[@id='jp-recent-content-jp-']/p[contains(.,'You currently have no recent journeys')]"));
        }

        public void PlanJourney(string From, string To)
        {
            
            journeyTo.SendKeys(To);
            journeyFrom.SendKeys(From);
        }

        public bool IsPageexits() => planJourney.Displayed;
        public bool IsCookieexits() => planJourneyCookieAccept.Displayed;
        public bool IsPageplanJourneyInvalidErrorexits() => planJourneyInvalidError.Displayed;
        
    }
}
    



using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTFLProject1.Pages
{
    class ResultsPage
    {

        public IWebDriver WebDriver { get; }
        public string To
        {
            get; private set;
        }
        public ResultsPage(IWebDriver webdriver)
        {

            WebDriver = webdriver;
        }
        public IWebElement planJourneyInvalidError => WebDriver.FindElement(By.XPath("//li[contains(.,'Journey planner could not find any results to your search. Please try again')]"));
        public IWebElement editLink => WebDriver.FindElement(By.XPath("//span[contains(.,'Edit journey')]"));

        public IWebElement journeyFrom => WebDriver.FindElement(By.Id("InputFrom"));
        public IWebElement journeyTo => WebDriver.FindElement(By.Id("InputTo"));
        public IWebElement updatejourney => WebDriver.FindElement(By.Id("plan-journey-button"));
        public IWebElement editSwapstn => WebDriver.FindElement(By.XPath("//a[contains(.,'Switch from and to')]"));
        public void ClickEditJourney() => editLink.Click();

        public void ClickupdateJourney() => updatejourney.Click();
        public bool IsErrorplanJourneyInvalidErrorexits() => planJourneyInvalidError.Displayed;
        public void CheckJourneyResults(string From, string To)
        {
          WebDriver.FindElement(By.XPath("//span[@class='jp-results-headline' and contains(.,'Journey results')]/../../../following-sibling::div[contains(.,'" + To + "')]"));
          WebDriver.FindElement(By.XPath("//span[@class='jp-results-headline' and contains(.,'Journey results')]/../../../following-sibling::div[contains(.,'" + From + "')]"));
        }
        //  
        public void EditJourneyFromTo(string From, string To)
        {
            journeyTo.Clear();
            
            journeyFrom.Clear();
            journeyTo.SendKeys(Keys.Clear);
            //journeyTo.SendKeys(Keys.Control, Keys.chord("a"));
            //journeyTo.SendKeys(Keys.Backspace);
            //journeyFrom.SendKeys(To);
            //journeyFrom.SendKeys(From);
            editSwapstn.Click();


        }

    }
}

 



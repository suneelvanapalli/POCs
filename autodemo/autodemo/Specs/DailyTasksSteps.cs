using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace autodemo.Specs
{
    [Binding]
    public class DailyTasksSteps
    {
        private static InternetExplorerDriver driver;

        [BeforeFeature]
        public static void Init()
        {
            driver = new InternetExplorerDriver();
        }

        [Given(@"I open browser with url '(.*)'")]
        public void GivenIOpenBrowserWithUrl(string p0)
        {   
            driver.Navigate().GoToUrl(p0);
        }
        
        [Given(@"login with my credentials")]
        public void GivenLoginWithMyCredentials()
        {
            var element = driver.FindElement(By.CssSelector("input[id*=Username]"));
            element.SendKeys("suneelkumarv");

            element = driver.FindElement(By.CssSelector("input[id*=Password]"));
            element.SendKeys("Password1");

            element = driver.FindElement(By.CssSelector("input[id*=LoginButton]"));

            element.Click();

            //element.Submit();


        }
        
        [Given(@"redirect to timehseet for this week")]
        public void GivenRedirectToTimehseetForThisWeek()
        {
            var element = driver.FindElement(By.CssSelector("span[id*=Tabs_Tab55_TitleLabel"));
            element.Click();

            element = driver.FindElement(By.CssSelector("input[id*=NewRow"));
            element.Click();

            element = driver.FindElement(By.CssSelector("input[name*=RequestID"));
            element.SendKeys("434662");

            element = driver.FindElement(By.CssSelector("input[name*=SaveButton"));
            element.Click();


        }
        
        [When(@"I enter RMS code")]
        public void WhenIEnterRMSCode()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should save")]
        public void ThenIShouldSave()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

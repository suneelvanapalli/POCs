using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace autodemo.Specs
{
    [Binding]
    public class LoginSteps
    {
        private static ChromeDriver driver;

        [BeforeFeature]
        public static void Init()
        {
            driver = new ChromeDriver();
        }

        [AfterFeature]
        public static void Dispose()
        {
            //driver.Close();
        }


        [Given(@"I am an aviser")]
        public void GivenIAmAnAviser()
        {
            var devDI = "http://bdt415sv/DST.OD.UI.OMW.Adviser/Login";
            driver.Navigate().GoToUrl(devDI);
        }
        
        [When(@"I enter my credentials")]
        public void WhenIEnterMyCredentials()
        {
            var element = driver.FindElementById("SetupPortalUsernameEntry");
            element.SendKeys("fauser01");            

            element = driver.FindElementById("SetupPortalPasswordEntry");
            element.SendKeys("Password01#");

            element.Submit();


        }
        
        [Then(@"I should successfully login to the portal")]
        public void ThenIShouldSuccessfullyLoginToThePortal()
        {
            Assert.AreEqual("Adviser", driver.Title);
        }

        [Then(@"I should redirect to User profile page")]
        public void WhenIShouldRedirectToUserProfilePage()
        {
            var url = "http://bdt415sv/DST.OD.UI.OMW.Adviser/system-admin/firm-admin-user-profile/#?uid=Fauser01";

            driver.Navigate().GoToUrl(url);
        }

    }
}

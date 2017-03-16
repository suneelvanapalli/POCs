using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodemo
{
    [TestFixture()]
    public class automationDemo
    {
        [Test()]
        public void OpenBrowser()
        {
            var driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl("https://app.pluralsight.com/id?redirectTo=/");

            var element = driver.FindElementsByName("Username").Single();
            element.SendKeys("suneelkumarv");

            element = driver.FindElementsByName("Password").Single();
            element.SendKeys("password1!");

            element.Submit();

            driver.Close();

        }








    }
}

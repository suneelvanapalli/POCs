using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitTimeSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www1.hays.com.au/HaysOnline/Login.aspx?Reason=session");

            var element = driver.FindElementByCssSelector("[id$=LoginID]");
            element.SendKeys("637991");

            element = driver.FindElementByCssSelector("[id$=Password]");
            element.SendKeys("Password1!");

            element = driver.FindElementByCssSelector("[id$=LoginButton]");
            element.Click();

            Console.ReadKey();
            driver.Close();
        }
    }
}

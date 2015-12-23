using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WentTours
{
    class FindFlightsPage
    {
        private IWebDriver driver;

        public FindFlightsPage(IWebDriver driver)
        {
            this.driver = driver;

           // if (driver.Title != "Welcome: Mercury Tours")
              //  throw new NoSuchWindowException("This is not the FindFlight page");
        }

      
        public void Do()
        {
            driver.FindElement(By.CssSelector("input[name=tripType][value=oneway]")).Click();

            driver.FindElement(By.Name("passCount")).FindElement(By.CssSelector("option[value='3']")).Click();
            driver.FindElement(By.Name("fromPort")).FindElement(By.CssSelector("option[value='Paris']")).Click();

            driver.Manage().Window.Maximize();
            driver.FindElement(By.CssSelector("input[name=servClass][value=Business]")).Click();

            driver.FindElement(By.Name("findFlights")).Click();
            driver.FindElement(By.CssSelector("input[name=outFlight][value='Blue Skies Airlines$361$271$7:10']")).Click();
            //Thread.Sleep(1000);
            driver.FindElement(By.Name("reserveFlights")).Click();
            //driver.Manage().Window.Maximize();
            
            driver.FindElement(By.Name("passFirst0")).SendKeys("Ioana");
            driver.FindElement(By.Name("passLast0")).SendKeys("Pop");

            driver.FindElement(By.Name("pass.0.meal")).FindElement(By.CssSelector("option[value='BLML']")).Click();
            driver.FindElement(By.Name("creditnumber")).SendKeys("1234565789365426");

            IWebElement element = driver.FindElement(By.Name("cc_exp_dt_mn"));
            IList<IWebElement> AllDropDownList = element.FindElements(By.XPath("//option"));
            int DpListCount = AllDropDownList.Count;
            for (int i = 0; i < DpListCount; i++)
            {
                if (AllDropDownList[i].Text == "02")
                {
                    AllDropDownList[i].Click();
                }
            }
            //driver.FindElement(By.Name("cc_exp_dt_mn")).FindElement(By.PartialLinkText("01")).Click();
            driver.FindElement(By.Name("cc_exp_dt_yr")).FindElement(By.CssSelector("option[value='2010']")).Click();

            driver.FindElement(By.Name("ticketLess")).Click();
            driver.FindElement(By.Name("buyFlights")).Click();
        }
        public LoginPage Logout()
        {
           driver.Navigate().GoToUrl("http://newtours.demoaut.com/");
           return new LoginPage(driver);
        }
    }
}

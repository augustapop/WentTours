﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Drawing.Imaging;

namespace WentTours
{
    [TestClass]
    public class TestWithFirefoxDriver
    {

        private string baseURL = "http://newtours.demoaut.com/";

        private int TimeOut = 30;
        IWebDriver driver = new FirefoxDriver();

       // [TestMethod]
    //    public void TestPOM()
      //  {
        //    driver.Navigate().GoToUrl(baseURL);
        //    LoginPage Login = new LoginPage(driver);

        //    FindFlightsPage FindFlights = Login.Do("augustapop@yahoo.com","Abigail_muresan1980");
        //    if (FindFlights != null)
        //    {
        //        FindFlights.Do();
        //        Thread.Sleep(2000);
        //         Login = FindFlights.Logout();
        //    }

        //    driver.Close();
        //}
        [TestMethod]
        public void testSignInFirefox()
        {
          var driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TimeOut));
            driver.Navigate().GoToUrl(baseURL);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.Title.Contains("Welcome: Mercury Tours"), "Title is not Mercury Tours, but is: {0}", driver.Title);

            driver.Manage().Window.Maximize();
            var user = driver.FindElement(By.Name("userName"));
            user.SendKeys("augustapop");
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("Abigail_muresan1980");

            var btnSing = driver.FindElement(By.Name("login"));
            btnSing.Click();

            driver.FindElement(By.Name("userName")).SendKeys("augustapop@yahoo.com");
            driver.FindElement(By.Name("password")).SendKeys("Abigail_muresan1980");

            var search = driver.FindElement(By.ClassName("footer"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(search.Text.Contains("Mercury"));
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("login")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("input[name=tripType][value=oneway]")).Click();

            driver.FindElement(By.Name("passCount")).FindElement(By.CssSelector("option[value='3']")).Click();
            driver.FindElement(By.Name("fromPort")).FindElement(By.CssSelector("option[value='Paris']")).Click();


            driver.FindElement(By.CssSelector("input[name=servClass][value=Business]")).Click();

            driver.FindElement(By.Name("findFlights")).Click();
            driver.FindElement(By.CssSelector("input[name=outFlight][value='Blue Skies Airlines$361$271$7:10']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("reserveFlights")).Click();

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


        //    //driver.FindElement(By.PartialLinkText("mercurywelcome.php")).Click();
        //    //(By.xpath("//img[@src ='images/buttons/button_template.gif' and @alt='Upload Selected']"))
        //    //img[contains(@src,'/img/logo/new_logo.jpg')]
            Thread.Sleep(4000);

        //    // driver.GetScreenshot().SaveAsFile(@"Tourist1.png", ImageFormat.Png);
            driver.Navigate().GoToUrl(baseURL);
            driver.Close();
        }
    }
}

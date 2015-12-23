using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WentTours
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            //if (driver.Title != "Welcome: Mercury Tours")
            //    throw new NoSuchWindowException("This is not Login page");
        }
        public FindFlightsPage Do(string UserName, string Password)
        {
            driver.FindElement(By.Name("userName")).SendKeys(UserName);
            driver.FindElement(By.Name("password")).SendKeys(Password);
            driver.FindElement(By.Name("login")).Click();
            return new FindFlightsPage(driver);
        }
    }
}

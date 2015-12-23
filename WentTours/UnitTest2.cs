using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WentTours
{
    [TestClass]
    public class UnitTest2
    {
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //    //get the browsername from your app.config file
        //    string browserName = ConfigurationManager.AppSettings["BrowserName"];

        //    if (MainCall.WebDriver == null)
        //        MainCall.InitializeDriver(browserName);

        //}

        [TestMethod]
        public void Login()
        {
            MainCall.WebDriver.Manage().Window.Maximize();
            MainCall.WebDriver.Navigate().GoToUrl(URL);         
            MainCall.LoginPage.FillUserName(id);
            MainCall.LoginPage.FillPassword(password);
            MainCall.LoginPage.ClickSignInButton();
        }
    }
}

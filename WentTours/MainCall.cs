using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WentTours
{

   public class MainCall
    {

        public static IWebDriver WebDriver = null;

        public static void InitializeDriver(string BrowserName)
        {
            if (WebDriver == null)
            {

                string DRIVER_PATH = @"C:\automation\driversFolder\";

                switch (BrowserName)
                {
                    case "IE":

                        WebDriver = new InternetExplorerDriver(DRIVER_PATH);

                        break;

                    case "FF":

                        WebDriver = new FirefoxDriver();
                        break;


                    case "CR":

                        WebDriver = new ChromeDriver(DRIVER_PATH);
                        break;

                    default:
                        WebDriver = new FirefoxDriver();
                        break;

                }

            }

        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WentTours
{
  public static   class Browser
    {
     
      private static IWebDriver WebDriver;

      internal static string Title
      {
          get { return WebDriver.Title; }
      }
      internal static string PageSource
      {
          get { return WebDriver.PageSource; }
      }

      internal static IWebDriver getDriver
      {
          get { return WebDriver; }
      }

      internal static ISearchContext Driver
      {
          get { return WebDriver; }
      }

      internal static void Goto(string Url)
      {
          WebDriver.Url = Url;
      }

      internal static WebDriverWait Wait()
      {
          return new WebDriverWait(WebDriver,TimeSpan.FromSeconds(30));
      }

      internal static string GetInnerHtml(IWebElement element)
      {
          var js = Driver as IJavaScriptExecutor;
          var result = "";
          try
          {
              if (js != null)
              {
                  result = (string)js.ExecuteScript("return arguments[0].innerHTML;", element);
              }
          }
          catch (Exception e)
          {
              Console.WriteLine(e.Message);
              throw;
          }
          return result;
      }

      public static void Quit()
      {
          WebDriver.Quit();
      }

      internal static void MaximizeWindow()
      {
          WebDriver.Manage().Window.Maximize();
      }

      //new browser window

      //public static void Open()
      //{
      //    try
      //    {
      //        WebDriver = (IWebDriver)Activator.CreateInstance("WebDriver", Setup.Settings.Browser).Unwrap();
      //    }
      //    catch (ArgumentNullException e1)
      //    {
      //        Console.WriteLine("Browser was not found. Check a browser has been chosen in the app.config file." + e1.Message);
      //        throw;
      //    }
      //    catch (TargetInvocationException e2)
      //    {
      //        Console.WriteLine("Browser.Open() encountered an error. Check Driver location. " + e2.Message);
      //    }
      //    catch (Exception e3)
      //    {
      //        Console.WriteLine("Browser.Open() encountered an error." + e3.Message);
      //    }
      //    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
      //    MaximizeWindow();
      //}

      public static bool HasNewWindow()
      {
          return WebDriver.WindowHandles.Count > 1;
      }
      public static IWebDriver GetNewWindow()
      {
          string parentWindow = WebDriver.CurrentWindowHandle;

          string popupHandle = string.Empty;
          IReadOnlyCollection<string> windowHandles = WebDriver.WindowHandles;


          foreach (string handle in windowHandles)
          {
              if (handle != parentWindow)
              {
                  popupHandle = handle;
                  return WebDriver.SwitchTo().Window(popupHandle);
              }
          }
          return null;
      }

      public static void GetCurrentWindow()
      {
          ReadOnlyCollection<string> windowHandles = WebDriver
              .WindowHandles;
          WebDriver.SwitchTo().Window(windowHandles[0]);
      }

      public static IWebDriver GetIFrame(IWebDriver window)
      {
          return window.SwitchTo().Frame(0);
      }
      public static void CloseNewWindow()
      {
          if (!HasNewWindow()) return;
      }
      public static void CloseNewWindow(IWebDriver window)
      { 
      window.Close();
      }

    }
}

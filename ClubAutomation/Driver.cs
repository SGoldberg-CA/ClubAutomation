using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Threading;
using System.IO;
using Microsoft.JScript;
using OpenQA.Selenium.Remote;

namespace ClubAutomation
{
    public class Driver
    {
        public static IWebDriver Instance
        {
            get;
            set;
        }

        public static void Initialize()
        {
            var profile = new FirefoxProfile();
            var options = new ChromeOptions();
            var caps = new DesiredCapabilities();
            var agent = ConfigurationManager.AppSettings["Browser"];
            var driverDir = Directory.GetCurrentDirectory();

            switch (agent)
            {

                case "Firefox":
                    //profile.SetPreference("general.useragent.override", "Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X; rv:40.0.1) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
                    Instance = new FirefoxDriver(profile);
                    break;
                case "Chrome":
                    Instance = new ChromeDriver(options);
                    break;

                case "Galaxy S5":
                    options.EnableMobileEmulation("Galaxy S5");
                    Instance = new ChromeDriver(options);
                    break;

                case "iPhone 6":
                    options.EnableMobileEmulation("iPhone 6");
                    Instance = new ChromeDriver(options);
                    break;

                case "iPhone 6 Plus":
                    options.EnableMobileEmulation("iPhone 6 Plus");
                    Instance = new ChromeDriver(options);
                    break;

                case "iPad":
                    options.EnableMobileEmulation("iPad");
                    Instance = new ChromeDriver(options);
                    break;

                case "LG Optimus L70":
                    options.EnableMobileEmulation("LG Optimus L70");
                    Instance = new ChromeDriver(options);
                    break;

                case "Remote_CBT":
                    var username = ConfigurationManager.AppSettings["CbtUsername"];
                    var authkey = ConfigurationManager.AppSettings["CbtAuthkey"];
                    var browserApiName = ConfigurationManager.AppSettings["CbtBrowserApiName"];
                    var osApiName = ConfigurationManager.AppSettings["CbtOsApiName"];
                    var screenRes = ConfigurationManager.AppSettings["CbtScreenRes"];
                    var hub = ConfigurationManager.AppSettings["CbtHub"];

                    caps.SetCapability("browser_api_name", browserApiName);
                    caps.SetCapability("os_api_name", osApiName);
                    caps.SetCapability("screen_resolution", screenRes);
                    caps.SetCapability("record_video", "true");
                    caps.SetCapability("record_network", "true");
                    caps.SetCapability("username", username);
                    caps.SetCapability("password", authkey);
                    Instance = new RemoteWebDriver(new Uri(hub), caps, TimeSpan.FromSeconds(180));
                    break;

                #region NeedsWork
                //case "IE":
                //    Instance = new InternetExplorerDriver(driverDir);
                //    break;
                //case "Android":
                //    profile.SetPreference("general.useragent.override", "Mozilla/5.0 (Linux; U; Android 4.0.3; en-us; google_sdk Build/MR1) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");
                //    Instance = new FirefoxDriver(profile);
                //    break;
                //case "iPhone":
                //    profile.SetPreference("general.useragent.override", "Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_2 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8H7 Safari/6533.18.5");
                //    Instance = new FirefoxDriver(profile);
                //    break;
                //case "iPad":
                //    profile.SetPreference("general.useragent.override", "Mozilla/5.0(iPad; U; CPU iPhone OS 3_2 like Mac OS X; en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Version/4.0.4 Mobile/7B314 Safari/531.21.10");
                //    Instance = new FirefoxDriver(profile);
                //    break;
                #endregion

                default:
                    Instance = new ChromeDriver();
                    break;
            }

            TurnOnWait();
        }

        //Closes the instance of webdriver
        public static void Close()
        {
            Instance.Quit();
        }

        #region Wait

        //General wait based on seconds
        public static void Wait(int sec)
        {
            Thread.Sleep(sec * 1000);
        }

        //Wait for element to be visible within a specified time frame or else get timeout exception 
        public static IWebElement WaitElement(By by, int time = 10)
        {
            try
            {
                var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(time));
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        //Wait for element's title text to be visible within a specified time frame or else get timeout exception
        public static void WaitByTitle(string titleText, int time = 10)
        {
            try
            {
                var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(time));
                wait.Until(ExpectedConditions.TitleIs(titleText));
            }
            catch (WebDriverTimeoutException)
            {
                //CodedUILogger.Error("Timeout Exception", "", null, ex.Message);
            }
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        #endregion

        public static void ExecuteJScript(IWebElement select, string js = "arguments[0].style.visibility='visible'")
        {
            ((IJavaScriptExecutor)Instance).ExecuteScript(js, select);
        }

        public static Object ExecuteJScript(string js)
        {
            return ((IJavaScriptExecutor)Driver.Instance).ExecuteScript(js);
        }
    }
}


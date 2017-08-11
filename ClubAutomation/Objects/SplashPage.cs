using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;


namespace ClubAutomation.Objects
{
    class SplashPage
    {
        //expected page title
        public static string Title => "Deerfield Athletic Association";

        public static void AssertPageTitle()
        {
            Assert.AreEqual(Title, Page.PageTitle(), "Splash page title is not as expected");
        }

        //takes user to splash page url
        public static void GoTo()
        {
            var splashPage = ConfigurationManager.AppSettings["SplashPage"];

            Driver.Instance.Navigate().GoToUrl(splashPage);
        }

        //selects username field and enters username
        public static void EnterUsername()
        {
            var loginForm = Driver.Instance.FindElement(By.Id("signin_login_form"));
            var usernameField = loginForm.FindElement(By.Name("login"));
            var username = ConfigurationManager.AppSettings["Username"];

            usernameField.Click();
            usernameField.SendKeys(username);
        }

        //selects password field and enters password
        public static void EnterPassword()
        {
            var password = ConfigurationManager.AppSettings["Password"];

            Driver.Instance.FindElement(By.Id("password-text")).Click();
            Driver.Instance.FindElement(By.Id("password")).SendKeys(password);
        }

        //clicks login button 
        public static void ClickLoginBtn()
        {
            var loginForm = Driver.Instance.FindElement(By.Id("signin_login_form"));
            var loginBtn = loginForm.FindElement(By.LinkText("Login"));

            loginBtn.Click();
        }

        //validates that the error message that appears when an empty login is submitted is the expected message
        public static void EmptyLoginErrorMessage()
        {
            Assert.AreEqual("Incorrect Username or Password", Driver.Instance.FindElement(By.XPath("//*[@id='signin_login_form']/div[3]")).Text, "Error message is not as expected");
        }

        //validates that a red border appears around the username field
        public static void UsernameRedBorder()
        {
            var color = Driver.Instance.FindElement(By.XPath("//*[@id='signin_login_form']/div[1]")).GetCssValue("border-color");

            Assert.AreEqual("rgb(255, 111, 111)", color, "Missing red border around username field");
        }

        //validates that a red border appears around the password field
        public static void PasswordRedBorder()
        {
            var color = Driver.Instance.FindElement(By.XPath("//*[@id='signin_login_form']/div[2]")).GetCssValue("border-color");

            Assert.AreEqual("rgb(255, 111, 111)", color, "Missing red border around password field");
        }
    }
}


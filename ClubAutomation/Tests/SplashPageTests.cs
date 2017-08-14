using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubAutomation.Objects;
using ClubAutomation.Objects.Dashboard;
using System.Configuration;
using System;
using OpenQA.Selenium.Remote;
using ClubAutomation.Configurations;
using OpenQA.Selenium;

namespace ClubAutomation.Tests
{
    [TestClass]
    public class SplashPageTests : BaseTest
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [TestMethod]
        [Description("TC #, Verifying successful user login through splash page")]
        [TestCategory("splashPage")]

        public void splashPage_logIn()
        {
            var agent = ConfigurationManager.AppSettings["Browser"];
            var cbtapi = new CBTApi();
            var sessionId = ((RemoteWebDriver)Driver.Instance).SessionId.ToString();
            var caps = new DesiredCapabilities();

            if (agent == "Remote_CBT")
            {
                try
                {
                    caps.SetCapability("name", "Club Automation Test: splashPage_logIn");
                    caps.SetCapability("build", "TestCase #");

                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterUsername();
                    SplashPage.EnterPassword();
                    cbtapi.takeSnapshot(sessionId);
                    SplashPage.ClickLoginBtn();
                    LocationSelector.SelectLocation();
                    LocationSelector.SelectPos();
                    LocationSelector.ClickSelect();
                    DashboardPage.AssertLoggedUserName();
                    cbtapi.takeSnapshot(sessionId);
                    log.InfoFormat($"{TestContext.TestName} - Test Passed");
                    cbtapi.setScore(sessionId, "Pass");

                }
                catch (Exception e)
                {
                    var snapshotHash = cbtapi.takeSnapshot(sessionId);
                    cbtapi.setDescription(sessionId, snapshotHash, e.ToString());
                    cbtapi.setScore(sessionId, "Fail");
                    log.ErrorFormat($"{TestContext.TestName} - Test Failed", e.Message, e.StackTrace);
                    throw;
                }
            }
            else
            {
                try
                {
                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterUsername();
                    SplashPage.EnterPassword();
                    SplashPage.ClickLoginBtn();
                    LocationSelector.SelectLocation();
                    LocationSelector.SelectPos();
                    LocationSelector.ClickSelect();
                    DashboardPage.AssertLoggedUserName();
                    log.InfoFormat($"{TestContext.TestName} - Test Passed");
                }
                catch(Exception e)
                {
                    log.ErrorFormat($"{TestContext.TestName} - Test Failed", e.Message, e.StackTrace);
                    throw;
                }
            }
        }

        [TestMethod]
        [Description("TC #, Verify error message when invalid username is entered (valid password is entered) and login button is selected")]
        [TestCategory("splashPage")]

        public void splashPage_logIn_invalidUsername()
        {
            var agent = ConfigurationManager.AppSettings["Browser"]; 
            var cbtapi = new CBTApi(); 
            var sessionId = ((RemoteWebDriver)Driver.Instance).SessionId.ToString(); 
            var caps = new DesiredCapabilities(); 

            if (agent == "Remote_CBT") 
            {
                try
                {
                    caps.SetCapability("name", "splashPage_logIn_invalidUsername");
                    caps.SetCapability("build", "TestCase #");

                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterInvalidUsername();
                    SplashPage.EnterPassword();
                    cbtapi.takeSnapshot(sessionId);
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    cbtapi.takeSnapshot(sessionId); 
                    cbtapi.setScore(sessionId, "Pass"); 
                }
                catch (Exception e)
                {
                    var snapshotHash = cbtapi.takeSnapshot(sessionId);
                    cbtapi.setDescription(sessionId, snapshotHash, e.ToString()); 
                    cbtapi.setScore(sessionId, "Fail"); 
                }
            }
            else 
            {
                try
                {
                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterInvalidUsername();
                    SplashPage.EnterPassword();
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    log.InfoFormat($"{TestContext.TestName} - Test Passed");
                }
                catch (Exception e)
                {
                    log.ErrorFormat($"{TestContext.TestName} - Test Failed", e.Message, e.StackTrace);
                    throw;
                }
            }
        }

        [TestMethod]
        [Description("TC #, Verify error message when invalid password is entered (valid username is entered) and login button is selected")]
        [TestCategory("splashPage")]

        public void splashPage_logIn_invalidPassword()
        {
            var agent = ConfigurationManager.AppSettings["Browser"]; 
            var cbtapi = new CBTApi(); 
            var sessionId = ((RemoteWebDriver)Driver.Instance).SessionId.ToString(); 
            var caps = new DesiredCapabilities();
            
            if (agent == "Remote_CBT") 
            {
                try
                {
                    caps.SetCapability("name", "splashPage_logIn_invalidPassword");
                    caps.SetCapability("build", "TestCase #");

                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterUsername();
                    SplashPage.EnterInvalidPassword();
                    cbtapi.takeSnapshot(sessionId);
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    cbtapi.takeSnapshot(sessionId); 
                    cbtapi.setScore(sessionId, "Pass"); 
                }
                catch (Exception e)
                {
                    var snapshotHash = cbtapi.takeSnapshot(sessionId);
                    cbtapi.setDescription(sessionId, snapshotHash, e.ToString()); 
                    cbtapi.setScore(sessionId, "Fail"); 
                }
            }
            else 
            {
                try
                {
                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterUsername();
                    SplashPage.EnterInvalidPassword();
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    log.InfoFormat($"{TestContext.TestName} - Test Passed");
                }
                catch (Exception e)
                {
                    log.ErrorFormat($"{TestContext.TestName} - Test Failed", e.Message, e.StackTrace);
                    throw;
                }

            }
        }

        [TestMethod]
        [Description("TC # - Verify error message when username and password fields are left empty and login button is selected")]
        [TestCategory("splashPage")]

        public void splashPage_logIn_empty()
        {
            var agent = ConfigurationManager.AppSettings["Browser"];
            var cbtapi = new CBTApi();
            var sessionId = ((RemoteWebDriver)Driver.Instance).SessionId.ToString();
            var caps = new DesiredCapabilities();

            if (agent == "Remote_CBT")
            {
                try
                {
                    caps.SetCapability("name", "Club Automation Test: splashPage_logIn_empty");
                    caps.SetCapability("build", "TestCase #");

                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    cbtapi.takeSnapshot(sessionId);
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    cbtapi.setScore(sessionId, "Pass");
                }
                catch (Exception e)
                {
                    var snapshotHash = cbtapi.takeSnapshot(sessionId);
                    cbtapi.setDescription(sessionId, snapshotHash, e.ToString());
                    cbtapi.setScore(sessionId, "Fail");
                }
            }
            else
            {
                try
                {
                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    log.InfoFormat($"{TestContext.TestName} - Test Passed");
                }
                catch (Exception e)
                {
                    log.ErrorFormat($"{TestContext.TestName} - Test Failed", e.Message, e.StackTrace);
                    throw;
                }
            }
        }

        [TestMethod]
        [Description("TC # - Verify error message when username field is left empty (password is entered) and login button is selected")]
        [TestCategory("splashPage")]

        public void splashPage_logIn_emptyUsername()
        {
            var agent = ConfigurationManager.AppSettings["Browser"];
            var cbtapi = new CBTApi();
            var sessionId = ((RemoteWebDriver)Driver.Instance).SessionId.ToString();
            var caps = new DesiredCapabilities();

            if (agent == "Remote_CBT")
            {
                try
                {
                    caps.SetCapability("name", "splashPage_logIn_emptyUsername");
                    caps.SetCapability("build", "TestCase #");

                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterPassword();
                    cbtapi.takeSnapshot(sessionId);
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    cbtapi.takeSnapshot(sessionId);
                    cbtapi.setScore(sessionId, "Pass");
                }
                catch (Exception e)
                {
                    var snapshotHash = cbtapi.takeSnapshot(sessionId);
                    cbtapi.setDescription(sessionId, snapshotHash, e.ToString());
                    cbtapi.setScore(sessionId, "Fail");
                }
            }
            else
            {
                try
                {
                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterPassword();
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    log.InfoFormat($"{TestContext.TestName} - Test Passed");
                }
                catch (Exception e)
                {
                    log.ErrorFormat($"{TestContext.TestName} - Test Failed", e.Message, e.StackTrace);
                    throw;
                }
            }
        }

        [TestMethod]
        [Description("TC # - Verify error message when password field is left empty (valid username is entered) and login button is selected")]
        [TestCategory("splashPage")]

        public void splashPage_logIn_emptyPassword()
        {
            var agent = ConfigurationManager.AppSettings["Browser"];
            var cbtapi = new CBTApi();
            var sessionId = ((RemoteWebDriver)Driver.Instance).SessionId.ToString();
            var caps = new DesiredCapabilities();

            if (agent == "Remote_CBT")
            {
                try
                {
                    caps.SetCapability("name", "splashPage_logIn_emptyPassword");
                    caps.SetCapability("build", "TestCase #");

                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterUsername();
                    cbtapi.takeSnapshot(sessionId);
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    cbtapi.takeSnapshot(sessionId);
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    cbtapi.setScore(sessionId, "Pass");
                }
                catch (Exception e)
                {
                    var snapshotHash = cbtapi.takeSnapshot(sessionId);
                    cbtapi.setDescription(sessionId, snapshotHash, e.ToString());
                    cbtapi.setScore(sessionId, "Fail");
                }
            }
            else
            {
                try
                {
                    SplashPage.GoTo();
                    SplashPage.AssertPageTitle();
                    SplashPage.EnterUsername();
                    SplashPage.ClickLoginBtn();
                    SplashPage.EmptyLoginErrorMessage();
                    SplashPage.UsernameRedBorder();
                    SplashPage.PasswordRedBorder();
                    log.InfoFormat($"{TestContext.TestName} - Test Passed");
                }
                catch (Exception e)
                {
                    log.ErrorFormat($"{TestContext.TestName} - Test Failed", e.Message, e.StackTrace);
                    throw;
                }
            }
        }


    }
}


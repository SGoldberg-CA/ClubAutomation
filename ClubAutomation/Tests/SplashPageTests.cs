using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubAutomation.Objects;
using ClubAutomation.Objects.Dashboard;
using System.Configuration;
using System;
using OpenQA.Selenium.Remote;

namespace ClubAutomation.Tests
{
    [TestClass]
    public class SplashPageTests : BaseTest
    {
        [TestMethod]
        [Description("TC 1, Verifying successful user login through splash page")]
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
                SplashPage.GoTo();
                SplashPage.AssertPageTitle();
                SplashPage.EnterUsername();
                SplashPage.EnterPassword();
                SplashPage.ClickLoginBtn();
                LocationSelector.SelectLocation();
                LocationSelector.SelectPos();
                LocationSelector.ClickSelect();
                DashboardPage.AssertLoggedUserName();
            }
        }

        [TestMethod]
        [Description("")]
        [TestCategory("splashPage")]

        public void splashPage_logIn_invalidUserId()
        {

        }

        [TestMethod]
        [Description("")]
        [TestCategory("splashPage")]

        public void splashPage_logIn_invalidPassword()
        {
        }

        [TestMethod]
        [Description("TC# - Verify error message when username and password fields are left empty and login button is selected")]
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
                SplashPage.GoTo();
                SplashPage.AssertPageTitle();
                SplashPage.ClickLoginBtn();
                SplashPage.EmptyLoginErrorMessage();
                SplashPage.UsernameRedBorder();
                SplashPage.PasswordRedBorder();
            }
        }
    }
}


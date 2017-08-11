using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;

namespace ClubAutomation.Objects.Dashboard
{
    class DashboardPage
    {
        //Compares first and last name set in app.config to logged user's name in global header 
        public static void AssertLoggedUserName()
        {
            var firstName = ConfigurationManager.AppSettings["FirstName"];
            var lastName = ConfigurationManager.AppSettings["LastName"];
            var fullName = lastName + " " + firstName;
            var header = Driver.Instance.FindElement(By.Id("ca-header"));
            var username = header.FindElement(By.ClassName("logged-user-name")).Text;
            
            Assert.AreEqual(fullName, username, "Logged user's name is not displayed as expected");
        }

    }
}

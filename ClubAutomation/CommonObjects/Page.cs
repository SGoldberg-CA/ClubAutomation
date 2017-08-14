using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ClubAutomation.CommonObjects
{
    class Page
    {
        public static string PageTitle()
        {
            {
                //gets and returns the page title as a string

                var title = Driver.Instance.Title;

                return title;
            }
        }


    }
}

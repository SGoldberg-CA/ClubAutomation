using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubAutomation.Objects.Dashboard
{
    class LocationSelector
    {
        public static void ClickSelect()
        {
            var locationBx = Driver.Instance.FindElement(By.XPath("/html/body/div[11]"));
            var selectBtn = Driver.Instance.FindElement(By.Id("selectClubButton"));

            if(locationBx.Displayed == true)
            {
                selectBtn.Click();
            }

        }

        public static void SelectLocation()
        {
            var locDrop = Driver.Instance.FindElement(By.XPath("//*[@id='clubId_chosen']/a"));
            var results = Driver.Instance.FindElement(By.XPath("//*[@id='clubId_chosen']/div/ul"));

            locDrop.Click();
            results.FindElements(By.ClassName("active-result")).FirstOrDefault().Click();
        }

        public static void SelectPos()
        {
            var posDrop = Driver.Instance.FindElement(By.XPath("//*[@id='club_pos_1_chosen']/a"));
            var results = Driver.Instance.FindElement(By.XPath("//*[@id='club_pos_1_chosen']/div/ul"));

            posDrop.Click();
            results.FindElements(By.ClassName("active-result")).FirstOrDefault().Click();
        }
    }
}

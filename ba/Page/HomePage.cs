using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ba.Page
{
    public class HomePage : BasePage
    {
        private const string PageAddress = "https://www.ba.lt/lt";

        private IWebElement ddlLanguageSelection =>
            Driver.FindElement(By.XPath("//a [@href='#a']"));

        private IWebElement btnAcceptCookies =>
            Driver.FindElement(By.CssSelector(".modal-cacsp-btn.modal-cacsp-btn-accept"));
        private IWebElement lnkToTechnologiesPage => Driver.FindElement(By.XPath("//a [@href='https://www.ba.lt/en/technologies/']"));
        private IWebElement lnkToContactsPage => Driver.FindElement(By.XPath("//a [@href='https://www.ba.lt/lt/kontaktai/']"));
        private IWebElement lnkToEnjoyItPage => Driver.FindElement(By.XPath("//a [@href='https://www.enjoyit.lt/']"));

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void GoToHomePage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void CloseCookies()
        {
            GetWait().Until(
                ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-cacsp-btn.modal-cacsp-btn-accept")));
            btnAcceptCookies.Click();
        }
        
        public void SelectEnglishLanguage()
        {
            GetWait().Until(
                ExpectedConditions.ElementIsVisible(By.XPath("//a [@href='#a']")));
            ddlLanguageSelection.Click();
            Driver.FindElement(By.XPath("//a [@href='https://www.ba.lt/en/']")).Click();
        }

        public void VerifyHomePageH1AndBrowserTitle(string pageTitle, string mainH1)
        {
            string h1ActualText = Driver.FindElement(By.CssSelector(".video__text-title >h1")).Text;
            string homePageTitleEnText = Driver.Title;
            Assert.AreEqual(pageTitle, homePageTitleEnText, "The title is wrong");
            Assert.AreEqual(mainH1, h1ActualText, "The H1 is wrong");
        }

        public void GoToTechnologiesPage()
        {
            lnkToTechnologiesPage.Click();
        }
        
        public void GoToContactsPage()
        {
            lnkToContactsPage.Click();
        }

        public void GoToEnjoyItPage()
        {
            lnkToEnjoyItPage.Click();
        }
        
    }
}
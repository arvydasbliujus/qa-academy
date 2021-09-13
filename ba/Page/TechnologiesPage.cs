using NUnit.Framework;
using OpenQA.Selenium;

namespace ba.Page
{
    public class TechnologiesPage : BasePage
    {
        private IWebElement pageDescription => Driver.FindElement(By.XPath("//*[@id='post-1756']/div/p[2]"));

        public TechnologiesPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        public void VerifyPageIntroParagraph(string text)
        {
            Assert.AreEqual(text, pageDescription.Text, "Wrong Page decription");
        }
        public void GoToDotNetDevelopmentPage()
        {
            Driver.FindElement(By.LinkText(".NET")).Click();
        }
    }
}
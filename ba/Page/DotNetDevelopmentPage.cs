using NUnit.Framework;
using OpenQA.Selenium;

namespace ba.Page
{
    public class DotNetDevelopmentPage : BasePage
    {
        public DotNetDevelopmentPage(IWebDriver webDriver) : base(webDriver) {}
        
        public void VerifyDotNetDevelopmentPageH1AndBrowserTitle(string pageTitle, string mainH1)
        {
            string h1ActualText = Driver.FindElement(By.CssSelector("#post-1783 > div > h1")).Text;
            string dotNetDevelopmentPageTitleEnText = Driver.Title;
            Assert.AreEqual(pageTitle, dotNetDevelopmentPageTitleEnText, "The title is wrong");
            Assert.AreEqual(mainH1, h1ActualText, "The H1 is wrong");
        }
    }
}


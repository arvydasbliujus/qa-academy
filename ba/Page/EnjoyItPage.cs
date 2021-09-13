using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ba.Page
{
    public class EnjoyItPage : BasePage
    {
        private const string AddressUrl = "https://www.enjoyit.lt/";
        
        private IWebElement headingH2 => Driver.FindElement(By.CssSelector(".top-text > h2"));
        public EnjoyItPage(IWebDriver webDriver) : base(webDriver) {}
        
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        
        public void VerifyH2()
        {
            Assert.AreEqual("IT is life. Enjoy IT", headingH2.Text, "Nope");
        }
    }
}
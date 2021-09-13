using ba.Drivers;
using ba.Page;
using ba.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace ba.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static HomePage _homePage;
        public static TechnologiesPage _technologiesPage;
        public static DotNetDevelopmentPage _dotNetDevelopmentPage;
        public static ContactsPage _contactsPage;
        public static EnjoyItPage _enjoyItPage;
        
        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _homePage = new HomePage(driver);
            _technologiesPage = new TechnologiesPage(driver);
            _dotNetDevelopmentPage = new DotNetDevelopmentPage(driver);
            _contactsPage = new ContactsPage(driver);
            _enjoyItPage = new EnjoyItPage(driver);
        }
        
        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                ScreenShots.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
             driver.Quit();
        }
    }
}
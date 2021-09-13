using NUnit.Framework;

namespace ba.Test
{
    public class BaTests : BaseTest
    {
        [Test, Order(1)]
        public static void TestLtToEnLanguage()
        {
            _homePage.GoToHomePage();
            _homePage.CloseCookies();
            _homePage.SelectEnglishLanguage();
            _homePage.VerifyHomePageH1AndBrowserTitle("Custom Software Development Company | Baltic Amadeus",
                "Business digitalization.\nSimplified.");
            _homePage.GoToTechnologiesPage();
            _technologiesPage.VerifyPageIntroParagraph(
                "Trust from our customers inspires us to turn challenges into innovative solutions.");
            _technologiesPage.GoToDotNetDevelopmentPage();
            _dotNetDevelopmentPage.VerifyDotNetDevelopmentPageH1AndBrowserTitle(
                ".NET Custom Development and Maintenance Services - Baltic Amadeus", ".NET Development Services");
        }

        [Test]
        public static void TestContacts()
        {
            _homePage.GoToHomePage();
            _homePage.GoToContactsPage();
            _contactsPage.VerifyContactsInfo("+37052780400", "info@ba.lt");
        }

        [Test]
        public static void TestFormValidationSuccess()
        {
            _homePage.GoToHomePage();
            _homePage.GoToContactsPage();
            _contactsPage.VerifyRequiredInputFields("Arvydas", "arvydasbliujus@gmail.com", "Ačiū už QA Akademiją", "Su programuotojų diena ir labai dėkui už QA Akademiją buvo faina ir naudina patirtis. p.s. soriukas už John Doe žinutes :)");
        }

        [Test]
        public static void TestFormValidationError()
        {
            _homePage.GoToHomePage();
            _homePage.GoToContactsPage();
            _contactsPage.PressSendBtn();
            _contactsPage.VerifyAllMandatoryFieldsValidation();
        }
        
         [Test]
         public static void TestEnjoyItPage()
        {
            _homePage.GoToHomePage();
            _homePage.GoToEnjoyItPage();
            _enjoyItPage.NavigateToPage();
            _enjoyItPage.VerifyH2();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ba.Page
{
    public class ContactsPage : BasePage
    {
        private IWebElement ContactPhoneNumber =>
            Driver.FindElement(By.CssSelector(".col.req > p > strong:nth-child(1)"));

        private IWebElement btnSend => Driver.FindElement(By.CssSelector(".wpcf7-form-control.wpcf7-submit"));

        private IWebElement ContactEmail =>
            Driver.FindElement(By.CssSelector(".col.req > p > strong:nth-child(3) > a"));

        private IWebElement inputFieldName => Driver.FindElement(By.XPath("//input[@name='your-name']"));
        private IWebElement inputFieldEmail => Driver.FindElement(By.XPath("//input[@name='your-email']"));
        private IWebElement inputFieldMessageTitle => Driver.FindElement(By.XPath("//input[@name='message-title']"));

        private IWebElement txtAreaMessageContent =>
            Driver.FindElement(By.CssSelector(".contact__text-input > label > span > textarea"));

        private IWebElement chkAcceptPrivatePolicy => Driver.FindElement(By.XPath("//input[@type='checkbox']"));

        private IReadOnlyCollection<IWebElement> allMandatoryInputFields =>
            Driver.FindElements(By.CssSelector(".wpcf7-validates-as-required"));

        public ContactsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void VerifyContactsInfo(string phoneNumber, string email)
        {
            Assert.AreEqual(phoneNumber.Replace(" ", ""), ContactPhoneNumber.Text.Replace(" ", ""),
                "Phone number is wrong");
            Assert.AreEqual(email, ContactEmail.Text, "Email address is wrong");
        }

        public void VerifyRequiredInputFields(string name, string email, string messageTitle, string message)
        {
            inputFieldName.SendKeys(name);
            inputFieldEmail.SendKeys(email);
            inputFieldMessageTitle.SendKeys(messageTitle);
            txtAreaMessageContent.SendKeys(message);
            chkAcceptPrivatePolicy.Click();
            btnSend.Click();
            string headingTitle = Driver.FindElement(By.CssSelector("h1.heading-title")).Text;
            Assert.AreEqual("Ačiū",headingTitle, "Wrong heading title");
        }

        public void PressSendBtn()
        {
            btnSend.Click();
            GetWait().Until(
                ExpectedConditions.ElementIsVisible(By.CssSelector(".wpcf7-not-valid")));
        }

        public void VerifyFirstNameValidation()
        {
            string classAttributeValue = allMandatoryInputFields.ElementAt(0).GetAttribute("class");
            Assert.IsTrue(classAttributeValue.Contains("wpcf7-not-valid"), "Wrong class");
        }

        public void VerifyAllMandatoryFieldsValidation()
        {
            foreach (IWebElement input in allMandatoryInputFields)
            {
                Assert.IsTrue(input.GetAttribute("class").Contains("wpcf7-not-valid"), "no class");
                IWebElement errorMsg = input.FindElement(By.XPath("//span[contains(@class, 'wpcf7-not-valid-tip')]"));
                Assert.IsTrue(errorMsg.Displayed);
            }
        }
    }
}
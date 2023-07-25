using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MailTestSelenium.Pages
{
    public class OutlookHomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public OutlookHomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60)); // Outlook is very slow, so I set 60 seconds
        }

        //private IWebElement NewEmailButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='New email']")));
        //private IWebElement InboxScrollBar => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[class='customScrollBar jEpCF']")));

        public void OpenParticularEmail(string subjectOfEmail)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[text()='{subjectOfEmail}'][1]"))).Click();

        }

        public void CheckIfEmailContainsParticularTextOrNot(string subjectOfEmail, string secretText)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(), '{subjectOfEmail}')]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains(text(), '{secretText}')]")));
        }

        public void ReplyBackToParticularEmailWithNewAlias(string senderEmailAddress, string subjectOfEmail, string newAlias)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(), '{subjectOfEmail}')][1]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[contains(text(), '{senderEmailAddress}')]")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[text()='Reply']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[class='dFCbN fGO0P dPKNh DziEn']"))).SendKeys($"Hello!\n" +
                $"Here is your new alias:\n\n" +
                $"---> {newAlias} <---\n\n" +
                $"Best regards, Alice.");
            System.Threading.Thread.Sleep(2000); // for demo purposes only

            // This try-catch block tries two locators of "send" button
            // If a browser window is small, it should be first locator
            // if a browser window is big enough, the 2nd locator will be applied
            try
            {
                driver.FindElement(By.CssSelector("i[data-icon-name='send']")).Click();
            }
            catch (NoSuchElementException)
            {
                driver.FindElement(By.XPath("//span[text()='Send']")).Click();
            }
            System.Threading.Thread.Sleep(1500); // for demo purposes only
        }
    }
}


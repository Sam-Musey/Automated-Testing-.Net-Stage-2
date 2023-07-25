using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleCloudPricingCalculatorTest.Pages
{
    public class YopmailGeneratorPage
    {
        private const string webPageUrl = "https://yopmail.com/email-generator";

        private IWebDriver driver;
        private WebDriverWait wait;

        public YopmailGeneratorPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        // --- EMAIL GENERATOR PAGE ELEMENTS --- //
        private IWebElement NewButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@onclick='newgen();']")));
        private IWebElement CopyToClipboardButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='cprnd']/descendant::span[text()='Copy to clipboard']")));
        private IWebElement GeneratedEmailAddress => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='egen']")));
        private IWebElement CheckInboxbutton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Check Inbox']")));

        // --- INBOX PAGE ELEMENTS --- //
        private IWebElement RefreshButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='md but textu f36']")));
        private IWebElement EstimatedMonthlyCost => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Estimated Monthly Cost:')]")));
        private IWebDriver EmailInboxSectionFrame => wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='ifnoinb']")));
        private IWebDriver EmailSectionFrame => wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='ifmail']")));

        public string GenerateNewEmailAddress()
        {
            NewButton.Click();
            CopyToClipboardButton.Click();
            string genaratedEmailAddress = GeneratedEmailAddress.Text;
            CheckInboxbutton.Click();
            return genaratedEmailAddress;
        }

        public string GetValueOfTotalEstimatedCost()
        {
            driver.Navigate().Refresh();
            EmailSectionFrame.SwitchTo();
            string[] textOfTotalCostSplittedBySpace = EstimatedMonthlyCost.Text.Split(' ');
            string valueOfTotalCost = textOfTotalCostSplittedBySpace[4];
            return valueOfTotalCost;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(webPageUrl);
        }
    }
}


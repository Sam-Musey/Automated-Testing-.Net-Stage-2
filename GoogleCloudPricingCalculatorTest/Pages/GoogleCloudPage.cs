using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleCloudPricingCalculatorTest.Pages
{
    public class GoogleCloudPage
    {
        private const string webPageUrl = "https://cloud.google.com";

        private IWebDriver driver;
        private WebDriverWait wait;

        public GoogleCloudPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private IWebElement SearchButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@aria-label='Search']")));

        public void SearchOnGoogleCloudPage(string textToBeSearched)
        {
            SearchButton.Click();
            SearchButton.SendKeys(textToBeSearched);
            Thread.Sleep(1500); // for demo purposes only
            SearchButton.SendKeys(Keys.Enter);
        }

        public GoogleCloudPricingCalculatorPage ClickOnFoundLinkInSearchResults(string foundLink)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//b[contains(text(), '{foundLink}')]"))).Click();
            return new GoogleCloudPricingCalculatorPage(driver);
        } 

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(webPageUrl);
        }
    }
}


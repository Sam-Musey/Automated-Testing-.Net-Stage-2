using GoogleCloudPricingCalculatorTest.Model;
using GoogleCloudPricingCalculatorTest.Service;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleCloudPricingCalculatorTest.Pages
{
    public class GoogleLoginPage
    {
        private const string webPageUrl = "https://mail.google.com/";
        private IWebDriver driver;
        private WebDriverWait wait;

        public GoogleLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // --- FRAMES --- //
        public IWebDriver Frame1 => wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@name='account']")));

        // --- LOGIN WEBPAGE ELEMENTS --- //
        private IWebElement EmailInput => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("identifierId")));
        private IWebElement EmailInputNextButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='identifierNext']/descendant::span[text()='Next']")));
        private IWebElement PasswordInput => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")));
        private IWebElement PasswordNextButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='passwordNext']/descendant::span[text()='Next']")));

        // --- GMAIL INBOX PAGE ELEMENTS --- //
        private IWebElement AccountIconButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@class='gb_n gbii']")));
        private IWebElement LoggedInUserName => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='q6rarf']/descendant::div[@class='Wdz6e']")));

        public void Login(User user)
        {
            EmailInput.SendKeys(user.GetUsername());
            EmailInputNextButton.Click();
            PasswordInput.SendKeys(user.GetPassword());
            PasswordNextButton.Click();
            Logger.logger.Information("The user logged in successfully");
        }

        public string GetLoggedInUserName()
        {
            AccountIconButton.Click();
            Frame1.SwitchTo();
            return LoggedInUserName.Text.ToLower();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(webPageUrl);
            Logger.logger.Information("Gmail login page opened");
        }
    }
}


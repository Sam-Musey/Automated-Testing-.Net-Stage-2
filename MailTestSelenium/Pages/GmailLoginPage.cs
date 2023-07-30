using MailTestSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailTestSelenium
{
    public class GmailLoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GmailLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private IWebElement EmailInput => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("identifierId")));
        private IWebElement EmailInputNextButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='identifierNext']/descendant::span[text()='Next']")));
        private IWebElement PasswordInput => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")));
        private IWebElement PasswordNextButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='passwordNext']/descendant::span[text()='Next']")));
        private IWebElement WrongLoginError => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='o6cuMc Jj6Lae']")));
        private IWebElement WrongPasswordError => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='OyEIQ uSvLId']")));

        public void EnterCorrectEmail() => EmailInput.SendKeys("Bob.webdriver.tester@gmail.com");
        public void EnterWrongEmail() => EmailInput.SendKeys("Bober.webdriver.tester@gmail.com");
        public void ClickNextOnEmailInput() => EmailInputNextButton.Click();
        public void EnterCorrectPassword() => PasswordInput.SendKeys("ThisIsEvenMoreSecurePassword");
        public void EnterWrongPassword() => PasswordInput.SendKeys("ThisIsWrongPassword");

        public GmailHomePage ClickNextOnPasswordInput()
        {
            PasswordNextButton.Click();
            return new GmailHomePage(driver);
        }

        public bool IsWrongPasswordErrorDisplayed()
        {
            try
            {
                IWebElement wrongPasswordMessage = WrongPasswordError;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsWrongLoginErrorDisplayed()
        {
            try
            {
                IWebElement wrongLoginMessage = WrongLoginError;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

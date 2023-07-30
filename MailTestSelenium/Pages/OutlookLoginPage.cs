using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using MailTestSelenium.Pages;

namespace MailTestSelenium
{
    public class OutlookLoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public OutlookLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private IWebElement SignInButton => wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Sign in")));
        private IWebElement EmailInput => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0116")));
        private IWebElement EmailInputNextButton => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));

        private IWebElement PasswordInput => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0118")));
        private IWebElement PasswordInputSignInButton => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
        private IWebElement DontShowThisAgainButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(), 'Don't show this again')]")));
        private IWebElement DontStaySignedInButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("idBtn_Back")));

        public void ClickSingIn() => SignInButton.Click();
        public void EnterEmail() => EmailInput.SendKeys("Alice_webdriver-tester@outlook.com");
        public void ClickNextOnEmailInput() => EmailInputNextButton.Click();
        public void ClickDontShowThisAgainButton() => DontShowThisAgainButton.Click();
        public OutlookHomePage ClickNoOnDontStaySignedInButton()
        {
            DontStaySignedInButton.Click();
            return new OutlookHomePage(driver);
        }

        public void EnterPassword() => PasswordInput.SendKeys("ThisIsVeryStrongPassword");
        public void ClickSignInOnPasswordInput() => PasswordInputSignInButton.Click();
    }
}


using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailTestSelenium.Pages
{
    public class GmailHomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GmailHomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        private IWebElement LoggedInUser => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Primary']")));
        private IWebElement ComposeButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Compose']")));
        private IWebElement RecipientsField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='agP aFw']")));
        private IWebElement SubjectField => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[name='subjectbox']")));
        private IWebElement EmailBodyField => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[class='Am Al editable LW-avf tS-tW']")));
        private IWebElement SendEmailButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[class='T-I J-J5-Ji aoO v7 T-I-atl L3']")));

        private IWebElement SettingsButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("svg[class='Xy']")));
        private IWebElement SeeAllSettingsButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='See all settings']")));
        private IWebElement AccountsAndImportButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Accounts and Import']")));
        private IWebElement EditInfoInAliasSectionButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='edit info']")));
        private IWebElement AliasTextField => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[id='cfn']")));
        private IWebElement AliasSaveChangesButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='bttn_sub']")));
        private IWebElement GmailButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='gb']/descendant::div[@class='gb_Hc gb_8d'][2]")));
        private IWebElement SentSection => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='aio UKr6le']/descendant::a[text()='Sent']")));
        private IWebElement RefreshButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='G-Ni J-J5-Ji']")));
        public string ChangeGmailAlias(string newAlias)
        {
            SettingsButton.Click();
            SeeAllSettingsButton.Click();
            AccountsAndImportButton.Click();
            EditInfoInAliasSectionButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]); // switch to a new window
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[id='cfn']")));
            AliasTextField.Clear();
            AliasTextField.SendKeys(newAlias);
            AliasSaveChangesButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles[0]); // switch back to a parent window
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id=':1']/descendant::div[text()='{newAlias} <bob.webdriver.tester@gmail.com>']")));
            return newAlias;
        }

        // This part of code is for generating random text for an email
        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string ComposeTestEmailWithRandomPart(int lengthOfRandomString)
        {
            string randomPartOfEmail = RandomString(lengthOfRandomString);
            ComposeButton.Click();
            RecipientsField.SendKeys("Alice_webdriver-tester@outlook.com");
            SubjectField.SendKeys("Very important email for you, Alice!");

            EmailBodyField.SendKeys("No, I'm just kidding :)\n" +
                "Don't get too excited, this is just a test letter!\n" +
                "And also don't try to make sense of the next part, it's kind of a secret text that will help identify this letter." +
                "\n\n ---> " + randomPartOfEmail + " <--- " +
                "\n\nBest regards,\nBob.");
            SendEmailButton.Click();
            return randomPartOfEmail;
        }

        public bool IsParticularEmailWasSent(string subjectOfSentEmail)
        {
            SentSection.Click();
            RefreshButton.Click();
            try
            {
                IWebElement emailSent = wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[@class='ae4 UI nH oy8Mbf']/descendant::span[contains(text(), '{subjectOfSentEmail}')]")));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsUserLoggedIn()
        {
            try
            {
                IWebElement loggedInUser = LoggedInUser;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsNewAliasApplied(string newAlias)
        {
            try
            {
                IWebElement NewAliasDisplayed = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id=':1']/descendant::div[text()='{newAlias} <bob.webdriver.tester@gmail.com>']")));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}


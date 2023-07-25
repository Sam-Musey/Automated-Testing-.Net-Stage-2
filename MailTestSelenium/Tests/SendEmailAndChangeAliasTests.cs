using MailTestSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MailTestSelenium;

[TestClass]
public class UnitTest1
{
    IWebDriver driver = new ChromeDriver();
    string newAlias;

    [TestMethod]
    public void Test1SendLetterFromGmailAndVerifyItInOutlookSucceeded()
    {
        // Login to Gmail account

        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        OutlookLoginPage outlookLoginPage = new OutlookLoginPage(driver);
        //driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.EnterCorrectPassword();
        GmailHomePage gmailHomePage = gmailLoginPage.ClickNextOnPasswordInput();

        // Send an email with random string (randomText variable) from Gmail to Outlook account

        string randomText = gmailHomePage.ComposeTestEmailWithRandomPart(40);

        // Check if the email was sent

        bool result = gmailHomePage.IsParticularEmailWasSent("Very important email for you, Alice!");
        Assert.IsTrue(result, "Email was not found");
        System.Threading.Thread.Sleep(1500); // for demo purposes only
        //driver.Close();

        // Login to Outlook account and check if an email with a specific subject has that random string or not

        //driver.SwitchTo().NewWindow(WindowType.Window);
        driver.Navigate().GoToUrl("https://outlook.live.com/owa/");
        outlookLoginPage.ClickSingIn();
        outlookLoginPage.EnterEmail();
        outlookLoginPage.ClickNextOnEmailInput();
        outlookLoginPage.EnterPassword();
        outlookLoginPage.ClickSignInOnPasswordInput();
        OutlookHomePage outlookHomePage = outlookLoginPage.ClickNoOnDontStaySignedInButton();

        // Reply back to that specific email with a new alias for Gmail account
        // This method also checks the sender email address

        newAlias = "Bob the builder";
        outlookHomePage.ReplyBackToParticularEmailWithNewAlias("Bob Tester", "Very important email for you, Alice!", newAlias);
        System.Threading.Thread.Sleep(1500); // for demo purposes only
        driver.Close();

    }

    [TestMethod]
    public void Test2ChangeGmailAccountAliasSucceeded()
    {
        // Login to Gmail account

        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.EnterCorrectPassword();
        GmailHomePage gmailHomePage = gmailLoginPage.ClickNextOnPasswordInput();

        // Change the alias of Gmail account

        newAlias = "Bob the builder";
        gmailHomePage.ChangeGmailAlias(newAlias);

        // Test if the new alias was applied

        bool result = gmailHomePage.IsNewAliasApplied(newAlias);
        Assert.IsTrue(result);
        System.Threading.Thread.Sleep(2000); // for demo purposes only
        driver.Close();
    }

}

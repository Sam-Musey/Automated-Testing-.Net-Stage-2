using MailTestSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailTestSelenium;

[TestClass]
public class SendEmailAndChangeAliasTests
{
    IWebDriver driver = new ChromeDriver();
    string newAlias;
    public TestContext TestContext { get; set; }

    /// <summary>
    /// 1. Login to Gmail account
    /// 2. Send an email with randomly generated string from Gmail to Outlook account
    /// 3. Check if the email was sent
    /// 4. Login to Outlook account and check if an email with a specific subject has that random string or not
    /// 5. Reply back to that specific email with a new alias for Gmail account (This method also checks the sender email address)
    /// </summary>
    [TestMethod]
    public void Test1SendLetterFromGmailAndVerifyItInOutlookSucceeded()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        OutlookLoginPage outlookLoginPage = new OutlookLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.EnterCorrectPassword();
        GmailHomePage gmailHomePage = gmailLoginPage.ClickNextOnPasswordInput();
        gmailHomePage.ComposeTestEmailWithRandomPart(40);
        bool result = gmailHomePage.IsParticularEmailWasSent("Very important email for you, Alice!");
        Assert.IsTrue(result, "Email was not found");

        driver.Navigate().GoToUrl("https://outlook.live.com/owa/");
        outlookLoginPage.ClickSingIn();
        outlookLoginPage.EnterEmail();
        outlookLoginPage.ClickNextOnEmailInput();
        outlookLoginPage.EnterPassword();
        outlookLoginPage.ClickSignInOnPasswordInput();
        OutlookHomePage outlookHomePage = outlookLoginPage.ClickNoOnDontStaySignedInButton();
        newAlias = "Bob the builder";
        outlookHomePage.ReplyBackToParticularEmailWithNewAlias("Bob Tester", "Very important email for you, Alice!", newAlias);
        driver.Close();
    }

    /// <summary>
    /// 1. Login to Gmail account
    /// 2. Change the alias of Gmail account
    /// 3. Test if the new alias was applied
    /// </summary>
    [TestMethod]
    public void Test2ChangeGmailAccountAliasSucceeded()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.EnterCorrectPassword();
        GmailHomePage gmailHomePage = gmailLoginPage.ClickNextOnPasswordInput();
        newAlias = "Bob the builder";
        gmailHomePage.ChangeGmailAlias(newAlias);

        bool result = gmailHomePage.IsNewAliasApplied(newAlias);
        Assert.IsTrue(result);
        driver.Close();
    }
}

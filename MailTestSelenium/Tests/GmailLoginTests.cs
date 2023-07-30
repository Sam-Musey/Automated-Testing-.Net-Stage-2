using MailTestSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailTestSelenium;

[TestClass]
public class GmailLoginTests
{
    IWebDriver driver = new ChromeDriver();

    [TestMethod]
    public void GmailLogInWithEmptyLoginThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.ClickNextOnEmailInput();

        bool result = gmailLoginPage.IsWrongLoginErrorDisplayed();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GmailLogInWithEmptyPasswordThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.ClickNextOnPasswordInput();

        bool result = gmailLoginPage.IsWrongPasswordErrorDisplayed();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GmailLogInWithWrongLoginThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterWrongEmail();
        gmailLoginPage.ClickNextOnEmailInput();

        bool result = gmailLoginPage.IsWrongLoginErrorDisplayed();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GmailLogInWithWrongPasswordThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.EnterWrongPassword();
        gmailLoginPage.ClickNextOnPasswordInput();

        bool result = gmailLoginPage.IsWrongPasswordErrorDisplayed();
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GmailLogInWithCorrectCredentialsSucceeded()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.EnterCorrectPassword();
        GmailHomePage gmailHomePage = gmailLoginPage.ClickNextOnPasswordInput();

        bool result = gmailHomePage.IsUserLoggedIn();
        Assert.IsTrue(result);
    }

    [TestCleanup]
    public void CleanUp()
    {
        driver.Quit();
    }
}

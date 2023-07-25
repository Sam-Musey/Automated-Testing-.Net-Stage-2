using MailTestSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MailTestSelenium;

[TestClass]
public class GmailLoginTests
{
    IWebDriver driver = new ChromeDriver();

    [TestMethod]
    public void Test1GmailLogInWithEmptyLoginThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.ClickNextOnEmailInput();

        bool result = gmailLoginPage.IsWrongLoginErrorDisplayed();
        Assert.IsTrue(result);
        System.Threading.Thread.Sleep(1000); // for demo purposes only
    }

    [TestMethod]
    public void Test2GmailLogInWithEmptyPasswordThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.ClickNextOnPasswordInput();

        bool result = gmailLoginPage.IsWrongPasswordErrorDisplayed();
        Assert.IsTrue(result);
        System.Threading.Thread.Sleep(1000); // for demo purposes only
    }

    [TestMethod]
    public void Test3GmailLogInWithWrongLoginThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterWrongEmail();
        gmailLoginPage.ClickNextOnEmailInput();

        bool result = gmailLoginPage.IsWrongLoginErrorDisplayed();
        Assert.IsTrue(result);
        System.Threading.Thread.Sleep(1000); // for demo purposes only
    }

    [TestMethod]
    public void Test4GmailLogInWithWrongPasswordThrowsError()
    {
        GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);
        driver.Navigate().GoToUrl("https://mail.google.com/");
        gmailLoginPage.EnterCorrectEmail();
        gmailLoginPage.ClickNextOnEmailInput();
        gmailLoginPage.EnterWrongPassword();
        gmailLoginPage.ClickNextOnPasswordInput();

        bool result = gmailLoginPage.IsWrongPasswordErrorDisplayed();
        Assert.IsTrue(result);
        System.Threading.Thread.Sleep(1000); // for demo purposes only
    }

    [TestMethod]
    public void Test5GmailLogInWithCorrectCredentialsSucceeded()
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

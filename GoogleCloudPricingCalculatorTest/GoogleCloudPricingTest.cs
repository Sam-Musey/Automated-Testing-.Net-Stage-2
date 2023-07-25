using System;
using GoogleCloudPricingCalculatorTest.Model;
using GoogleCloudPricingCalculatorTest.Pages;
using GoogleCloudPricingCalculatorTest.Service;
using GoogleCloudPricingCalculatorTest.WebDriverManager;
using OpenQA.Selenium;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace GoogleCloudPricingCalculatorTest;

[TestClass]
public class GoogleCloudPricingTest
{
    IWebDriver driver;
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void Initialize()
    {
        driver = WebDriverInstance.GetWebDriver();
    }

    [TestCleanup]
    public void CleanUp()
    {
        if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string jenkinsWorkspace = Environment.GetEnvironmentVariable("WORKSPACE");

            //string screenshotFilePathOfJenkins = Path.Combine(jenkinsWorkspace, $"screenshots/{TestContext.TestName}_{DateTime.Now.ToString("ddMMyyyy_HH-mm-ss")}.png");
            string screenshotFilePath = Path.Combine(Directory.GetCurrentDirectory(), "screenshots", $"{TestContext.TestName}_{DateTime.Now.ToString("ddMMyyyy_HH-mm-ss")}.png");
            string screenshotFolder = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");

            if (!Directory.Exists(screenshotFolder))
            {
                Directory.CreateDirectory(screenshotFolder);
            }
            screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            //screenshot.SaveAsFile(screenshotFilePathOfJenkins, ScreenshotImageFormat.Png);
            //TestContext.AddResultFile(screenshotFilePath);
        }
        WebDriverInstance.CloseDriver();
    }


    [TestMethod]
    [TestCategory("GooglePricingTest")]
    public void GenerateAndSendNewOfferCheckInboxAndVerifyTotalCost()
    {
        string totalEstimateCostOnGooglePage;
        string totalEstimateCostInEmail;

        // Open Google Cloud page and search for "Google Cloud Pricing Calculator"
        GoogleCloudPage googleCloudPage = new GoogleCloudPage(driver);
        googleCloudPage.OpenPage();
        googleCloudPage.SearchOnGoogleCloudPage("Google Cloud Pricing Calculator");
        Thread.Sleep(1500); // for demo purposes only
        GoogleCloudPricingCalculatorPage googleCloudPricingCalculatorPage = googleCloudPage.ClickOnFoundLinkInSearchResults("Google Cloud Pricing Calculator");

        // Fill in the form
        googleCloudPricingCalculatorPage.GoToFrameOfCalculator();
        googleCloudPricingCalculatorPage.FillInFormWithDefinedOptions();
        totalEstimateCostOnGooglePage = googleCloudPricingCalculatorPage.GetValueOfTotalEstimatedCost();
        Thread.Sleep(1500); // for demo purposes only

        // Open Yopmail page and generate new email address
        string receiverEmailAddress;
        YopmailGeneratorPage yopmailGeneratorPage = new YopmailGeneratorPage(driver);
        driver.SwitchTo().NewWindow(WindowType.Window);
        yopmailGeneratorPage.OpenPage();
        Thread.Sleep(3000); // for demo purposes only
        receiverEmailAddress = yopmailGeneratorPage.GenerateNewEmailAddress();
        Thread.Sleep(1500); // for demo purposes only

        // Send a generated offer from a calculator to a generated email address
        driver.SwitchTo().Window(driver.WindowHandles[0]);
        googleCloudPricingCalculatorPage.GoToFrameOfCalculator();
        googleCloudPricingCalculatorPage.SendTotalEstimateCostToEmail(receiverEmailAddress);
        Thread.Sleep(2500); // for demo purposes only
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        Thread.Sleep(1500); // for demo purposes only
        totalEstimateCostInEmail = yopmailGeneratorPage.GetValueOfTotalEstimatedCost();
        Thread.Sleep(1500); // for demo purposes only

        // Verify the total cost from Google Cloud Calculator equals the total cost from a received email
        Assert.AreEqual(totalEstimateCostOnGooglePage, totalEstimateCostInEmail,
            "The total estimate cost in Google Cloud Calculator and the one in email should be equal!");
    }

    [TestMethod]
    [TestCategory ("LoginTest")]
    public void GmailLoginTestSucceeded()
    {
        // This environment variable is assigned to the Environment from Jenkins Parameterized job
        string environment = Environment.GetEnvironmentVariable("Environment");

        // Here we can assign environment right in this test code
        //string environment = "qa";

        TestDataReader.SetEnvironment(environment);

        User testUser = UserCreator.CreateUserWithCredentialsFromProperty();
        GoogleLoginPage googleLoginPage = new GoogleLoginPage(driver);
        googleLoginPage.OpenPage();
        googleLoginPage.Login(testUser);

        string loggedInUserName = googleLoginPage.GetLoggedInUserName();
        Assert.AreEqual(loggedInUserName, testUser.GetUsername().ToLower(),
            "LoggedInUserName on Google page and UserName of testUser should be the same");   
    }
}

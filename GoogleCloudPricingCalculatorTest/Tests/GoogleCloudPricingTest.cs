using GoogleCloudPricingCalculatorTest.Model;
using GoogleCloudPricingCalculatorTest.Pages;
using GoogleCloudPricingCalculatorTest.Service;
using GoogleCloudPricingCalculatorTest.Tests;
using OpenQA.Selenium;

namespace GoogleCloudPricingCalculatorTest;

[TestClass]
public class GoogleCloudPricingTest : BaseTest
{
    /// <summary>
    /// 1. Open Google Cloud page, search for "Google Cloud Pricing Calculator", click the according link
    /// 2. Fill in the calculator form
    /// 3. Open Yopmail page and generate new email address
    /// 4. Send a generated offer from a calculator to the newly generated email address
    /// 5. Verify the total cost from Google Cloud Calculator equals the total cost from a received email
    /// </summary>
    [TestMethod]
    [TestCategory("GooglePricingTest")]
    public void GenerateAndSendNewOfferCheckInboxAndVerifyTotalCost()
    {
        GoogleCloudPage googleCloudPage = new GoogleCloudPage(driver);
        googleCloudPage.OpenPage();
        googleCloudPage.SearchOnGoogleCloudPage("Google Cloud Pricing Calculator");
        GoogleCloudPricingCalculatorPage googleCloudPricingCalculatorPage = googleCloudPage.ClickOnFoundLinkInSearchResults("Google Cloud Pricing Calculator");

        googleCloudPricingCalculatorPage.GoToFrameOfCalculator();
        googleCloudPricingCalculatorPage.FillInFormWithDefinedOptions();
        string totalEstimateCostOnGooglePage = googleCloudPricingCalculatorPage.GetValueOfTotalEstimatedCost();

        YopmailGeneratorPage yopmailGeneratorPage = new YopmailGeneratorPage(driver);
        driver.SwitchTo().NewWindow(WindowType.Window);
        yopmailGeneratorPage.OpenPage();
        string receiverEmailAddress = yopmailGeneratorPage.GenerateNewEmailAddress();

        driver.SwitchTo().Window(driver.WindowHandles[0]);
        googleCloudPricingCalculatorPage.GoToFrameOfCalculator();
        googleCloudPricingCalculatorPage.SendTotalEstimateCostToEmail(receiverEmailAddress);
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        string totalEstimateCostInEmail = yopmailGeneratorPage.GetValueOfTotalEstimatedCost();

        Assert.AreEqual(totalEstimateCostOnGooglePage, totalEstimateCostInEmail,
            "The total estimate cost in Google Cloud Calculator and the one in email should be equal!");
    }

    /// <summary>
    /// 1. environment variable is assigned to the Environment from Jenkins Parameterized job
    /// </summary>
    [TestMethod]
    [TestCategory ("LoginTest")]
    public void GmailLoginTestSucceeded()
    {
        string environment = Environment.GetEnvironmentVariable("Environment");
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

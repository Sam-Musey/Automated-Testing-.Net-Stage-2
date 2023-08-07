using GoogleCloudPricingCalculatorTest.WebDriverManager;
using OpenQA.Selenium;

namespace GoogleCloudPricingCalculatorTest.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;
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

                //string screenshotFilePath = Path.Combine(Directory.GetCurrentDirectory(), "screenshots", $"{TestContext.TestName}_{DateTime.Now.ToString("ddMMyyyy_HH-mm-ss")}.png");
                string screenshotFilePathOfJenkins = Path.Combine(jenkinsWorkspace, $"screenshots/{TestContext.TestName}_{DateTime.Now.ToString("ddMMyyyy_HH-mm-ss")}.png");
                string screenshotFolder = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");

                if (!Directory.Exists(screenshotFolder))
                {
                    Directory.CreateDirectory(screenshotFolder);
                }
                screenshot.SaveAsFile(screenshotFilePathOfJenkins, ScreenshotImageFormat.Png);
                //screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            }
            WebDriverInstance.CloseDriver();
        }
    }
}


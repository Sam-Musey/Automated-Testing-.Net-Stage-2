using GoogleCloudPricingCalculatorTest.Service;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleCloudPricingCalculatorTest.Pages
{
    public class GoogleCloudPricingCalculatorPage
    {
        private const string webPageUrl = "https://cloud.google.com/products/calculator";
        private IWebDriver driver;
        private WebDriverWait wait;
        
        public GoogleCloudPricingCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        // --- FRAMES --- //
        public IWebDriver WebpageFrame => wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@src='https://cloud.google.com/frame/products/calculator/index_d6a98ba38837346d20babc06ff2153b68c2990fa24322fe52c5f83ec3a78c6a0.frame']")));
        public IWebDriver CalculatorFrame => wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='myFrame']")));

        // --- CALCULATOR FORM ELEMENTS --- //
        private IWebElement ComputeEngineButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@title='Compute Engine']")));
        private IWebElement NumberOfInstancesField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@ng-model='listingCtrl.computeServer.quantity']")));
        private IWebElement SeriesField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.series']")));
        private IWebElement SeriesOptions => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//md-option[@value='{TestDataReader.Series}']")));
        private IWebElement MachineTypeField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.instance']")));
        private IWebElement MachineTypeOptions => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//md-option[@value='{TestDataReader.MachineType}']")));
        private IWebElement AddGPUsButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='mainForm']/descendant::div[contains(text(), 'Add GPUs')]")));
        private IWebElement GPUTypeField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.gpuType']")));
        private IWebElement GPUTypeOptions => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//md-option[@value='{TestDataReader.GPUType}']")));
        private IWebElement NumberOfGPUsField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.gpuCount']")));
        private IWebElement NumberOfGPUsOptions => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//md-option[@ng-repeat='item in listingCtrl.supportedGpuNumbers[listingCtrl.computeServer.gpuType]']/descendant::div[contains(text(), '{TestDataReader.NumberOfGPUs}')]")));
        private IWebElement LocalSSDField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.ssd']")));
        private IWebElement LocalSSDOptions => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[contains(text(), '{TestDataReader.LocalSSD}')]")));
        private IWebElement DatacenterLocationField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.location']")));
        private IWebElement DatacenterLocationOptions => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//md-option[@ng-repeat='item in listingCtrl.fullRegionList | filter:listingCtrl.inputRegionText.computeServer']/*[contains(text(), '{TestDataReader.DatacenterLocation}')]")));
        private IWebElement CommittedUsageField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.cud']")));
        private IWebElement CommittedUsageOptions => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"(//md-option/div[contains(text(), '{TestDataReader.CommittedUsage}')])[2]")));

        // --- SEND ESTIMATE ELEMENTS --- //
        private IWebElement AddToEstimateButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Add to Estimate')]")));
        private IWebElement EmailEstimateButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='Email Estimate']")));
        private IWebElement EmailEstimateEmailField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='email']")));
        private IWebElement EmailEstimateSendEmailButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Send Email')]")));
        private IWebElement TotalEstimatedCost => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='cpc-cart-total']")));

        public void FillInFormWithDefinedOptions()
        {
            NumberOfInstancesField.Click();
            NumberOfInstancesField.SendKeys(TestDataReader.NumberOfInstances);
            SeriesField.Click();
            SeriesOptions.Click();
            MachineTypeField.Click();
            MachineTypeOptions.Click();
            AddGPUsButton.Click();
            GPUTypeField.Click();
            GPUTypeOptions.Click();
            NumberOfGPUsField.Click();
            NumberOfGPUsOptions.Click();
            LocalSSDField.Click();
            LocalSSDOptions.Click();
            DatacenterLocationField.Click();
            DatacenterLocationOptions.Click();
            CommittedUsageField.Click();
            CommittedUsageOptions.Click();
            AddToEstimateButton.Click();
            Logger.logger.Information($"The form was filled in with the data from '{TestDataReader.testScenarioName}'");
        }

        public void SendTotalEstimateCostToEmail(string receiverEmailAddress)
        {
            EmailEstimateButton.Click();
            EmailEstimateEmailField.SendKeys(receiverEmailAddress);
            EmailEstimateSendEmailButton.Click();
            Logger.logger.Information($"Total estimate cost was sent to the email: {receiverEmailAddress}");
        }

        public string GetValueOfTotalEstimatedCost()
        {
            string[] textOfTotalCostSplittedBySpace = TotalEstimatedCost.Text.Split(' ');
            string valueOfTotalCost = textOfTotalCostSplittedBySpace[4];
            return valueOfTotalCost;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(webPageUrl);
            Logger.logger.Information("Gmail Cloud Pricing (calculator) page opened");
        }

        public void GoToFrameOfCalculator()
        {
            WebpageFrame.SwitchTo();
            CalculatorFrame.SwitchTo();
        }
    }
}


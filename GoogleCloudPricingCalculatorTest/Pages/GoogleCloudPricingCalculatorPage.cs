using System;
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
        public IWebDriver Frame1 => wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@src='https://cloud.google.com/frame/products/calculator/index_d6a98ba38837346d20babc06ff2153b68c2990fa24322fe52c5f83ec3a78c6a0.frame']")));
        public IWebDriver Frame2 => wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='myFrame']")));

        // --- CALCULATOR FORM ELEMENTS --- //
        public IWebElement ComputeEngineButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@title='Compute Engine']")));
        public IWebElement NumberOfInstancesField => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@ng-model='listingCtrl.computeServer.quantity']")));
        private IWebElement SeriesField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.series']")));
        private IWebElement SeriesN1Option => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@value='n1']")));
        private IWebElement MachineTypeField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.instance']")));
        private IWebElement MachineTypeN1Standard8Option => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@value='CP-COMPUTEENGINE-VMIMAGE-N1-STANDARD-8']")));
        private IWebElement AddGPUsButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='mainForm']/descendant::div[contains(text(), 'Add GPUs')]")));
        private IWebElement GPUTypeField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.gpuType']")));
        private IWebElement GPUTypeNVidiaTeslaV100Option => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@value='NVIDIA_TESLA_V100']")));
        private IWebElement NumberOfGPUsField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.gpuCount']")));
        private IWebElement NumberOfGPUs1Option => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_500']")));
        private IWebElement LocalSSDField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.ssd']")));
        private IWebElement LocalSSD2x375GbOption => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(), '2x375 GB')]")));
        private IWebElement DatacenterLocationField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.location']")));
        private IWebElement DatacenterLocationFrankfurtOption => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_256']")));
        private IWebElement DatacenterLocationSearch => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@ng-model='listingCtrl.inputRegionText.computeServer']")));
        private IWebElement DatacenterLocationMelbourneOption => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_250']")));
        private IWebElement CommittedUsageField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@ng-model='listingCtrl.computeServer.cud']")));
        private IWebElement CommittedUsage1YearOption => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_136']")));

        // --- SEND ESTIMATE ELEMENTS --- //
        private IWebElement AddToEstimateButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Add to Estimate')]")));
        private IWebElement EmailEstimateButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='Email Estimate']")));
        private IWebElement EmailEstimateEmailField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='email']")));
        private IWebElement EmailEstimateSendEmailButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Send Email')]")));
        private IWebElement TotalEstimatedCost => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='cpc-cart-total']")));

        public void FillInFormWithDefinedOptions()
        {
            //ComputeEngineButton.Click();
            NumberOfInstancesField.Click();
            NumberOfInstancesField.SendKeys("4");
            SeriesField.Click();
            SeriesN1Option.Click();
            MachineTypeField.Click();
            MachineTypeN1Standard8Option.Click();
            AddGPUsButton.Click();
            GPUTypeField.Click();
            GPUTypeNVidiaTeslaV100Option.Click();
            NumberOfGPUsField.Click();
            NumberOfGPUs1Option.Click();
            LocalSSDField.Click();
            LocalSSD2x375GbOption.Click();
            DatacenterLocationField.Click();
            //DatacenterLocationFrankfurtOption.Click(); //NVIDIA TESLA V100 is not available for Frankfurt
            DatacenterLocationMelbourneOption.Click();
            CommittedUsageField.Click();
            CommittedUsage1YearOption.Click();
            AddToEstimateButton.Click();
        }

        public void SendTotalEstimateCostToEmail(string receiverEmailAddress)
        {
            EmailEstimateButton.Click();
            EmailEstimateEmailField.SendKeys(receiverEmailAddress);
            Thread.Sleep(1500); // for demo purposes only
            EmailEstimateSendEmailButton.Click();
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
        }

        public void GoToFrameOfCalculator()
        {
            Frame1.SwitchTo();
            Frame2.SwitchTo();
        }
    }
}


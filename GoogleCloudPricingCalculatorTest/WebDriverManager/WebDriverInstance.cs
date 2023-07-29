using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleCloudPricingCalculatorTest.WebDriverManager
{
    public class WebDriverInstance
    {
        private static IWebDriver driver;

        public static IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}


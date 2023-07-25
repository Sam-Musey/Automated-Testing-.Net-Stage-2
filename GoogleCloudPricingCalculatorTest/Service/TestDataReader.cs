using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;

namespace GoogleCloudPricingCalculatorTest.Service
{
    public static class TestDataReader
    {
        public static IConfigurationRoot Configuration { get; private set; }

        public static void SetEnvironment(string environment)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "TestData", $"appsettings.{environment}.json"); // CORRECT ONE
            //string filePath = "../../../TestData/" + $"appsettings.{environment}.json"; // Why does this not work :(((
            
            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public static string GetUsername()
        {
            return Configuration["Username"];
        }

        public static string GetPassword()
        {
            return Configuration["Password"];
        }
    }
}


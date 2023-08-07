using Microsoft.Extensions.Configuration;

namespace GoogleCloudPricingCalculatorTest.Service
{
    public static class TestDataReader
    {
        public static IConfigurationRoot Configuration { get; private set; }
        public static string testScenarioName;

        public static void SetEnvironment(string environment)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "TestData", $"appsettings.{environment}.json");
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

        public static void SetTestScenario(string testScenario)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "TestData", $"{testScenario}.json");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            testScenarioName = testScenario;
        }

        public static string NumberOfInstances => Configuration["NumberOfInstances"];
        public static string Series => Configuration["Series"];
        public static string MachineType => Configuration["MachineType"];
        public static string GPUType => Configuration["GPUType"];
        public static string NumberOfGPUs => Configuration["NumberOfGPUs"];
        public static string LocalSSD => Configuration["LocalSSD"];
        public static string DatacenterLocation => Configuration["DatacenterLocation"];
        public static string CommittedUsage => Configuration["CommittedUsage"];
    }
}


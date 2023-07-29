using Serilog;

namespace GoogleCloudPricingCalculatorTest.Service
{
    public class Logger
    {
        public static ILogger logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console(outputTemplate:
            "[{Timestamp:yyy-MM-dd HH:mm:ss}] [{Level}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File("logs/SerilogLogFile-.txt", rollingInterval: RollingInterval.Day, outputTemplate:
            "[{Timestamp:yyy-MM-dd HH:mm:ss}] [{Level}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
    }
}


using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

namespace ToDoList.Logger
{
    public static class LoggerService
    {
        private static IConfigurationRoot config;
        static LoggerService()
        {
            config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
        }

        public static void logInformation(string information)
        {
            DateTime dateTime = DateTime.Now;
            Log.Information($"{dateTime} - {information}");
        }

        public static void logError(string error)
        {
            DateTime dateTime = DateTime.Now;
            Log.Error($"{dateTime} - {error}");
        }

    }
}

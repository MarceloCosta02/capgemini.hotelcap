using Microsoft.Extensions.Configuration;
using System;

namespace apihotelcap.Configuration
{
    public static class ConfigurationHelper
    {
        public static string GetAppSettingsKeyConfig(string nameKey)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            return config.GetSection($"AppSettings:{nameKey}").Value;
        }
    }
}

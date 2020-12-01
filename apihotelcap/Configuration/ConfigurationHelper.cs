using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Configuration
{
    public class ConfigurationHelper
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

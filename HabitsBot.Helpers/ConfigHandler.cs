using Microsoft.Extensions.Configuration;
using System;

namespace HabitsBot.Helpers
{
    public static class ConfigHandler
    {
        private const string configPath = "appSettingsSample.json";
        public static IConfigurationRoot GetJsonConfigurationFromPath(string path)
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile(path);
            var config = configBuilder.Build();

            return config;
        }

        public static IConfigurationRoot GetJsonConfiguration() => GetJsonConfigurationFromPath(configPath);
    }
}

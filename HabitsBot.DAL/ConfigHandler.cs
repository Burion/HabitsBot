using Microsoft.Extensions.Configuration;
using System;

namespace HabitsBot.DAL
{
    public static class ConfigHandler
    {
        public static IConfigurationRoot GetJsonConfigurationFromPath(string path)
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appSettings.json");
            var config = configBuilder.Build();

            return config;
        }
    }
}

using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace HabitsBot.DAL
{
    public static class ConfigHandler
    {
        public static IConfigurationRoot GetJsonConfigurationFromPath(string path)
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appSettings.json");
            var config = configBuilder.Build();

            return config;
        }
    }
}

using Microsoft.Extensions.Configuration;
using System.IO;

namespace CustodiaPlataforma.Tests.Configuration
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration config;

        public ConfigurationHelper()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }

        public static ConfigurationHelper Build()
        {
            return new ConfigurationHelper();
        }

        public string BaseUrl => config["BaseUrl"];
    }
}

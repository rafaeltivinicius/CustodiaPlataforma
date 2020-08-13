using CustodiaPlataforma.Infra.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustodiaPlataforma.API.Configuration.Extensions
{
    public static class BindConfigurationExtensions
    {
        public static void AddBindConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ApiConfiguration();
            configuration.Bind("ApiConfiguration", config);
            services.AddSingleton(config);
        }
    }
}

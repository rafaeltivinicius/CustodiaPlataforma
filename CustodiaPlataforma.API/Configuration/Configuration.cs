using CustodiaPlataforma.API.Configuration.DependencyInjection;
using CustodiaPlataforma.API.Configuration.Extensions;
using CustodiaPlataforma.API.Configuration.ILogger;
using CustodiaPlataforma.API.Configuration.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustodiaPlataforma.API.Configuration
{
    public static class Configuration
    {
        public static void AddConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            RepositoriesDI.Register(service);
            ServicesDI.Register(service);
            SwaggerConfiguration.RegisterSwagger(service);
            SerilogConfiguration.CreateLogger();

            service.AddBindConfiguration(configuration);
        }
    }
}

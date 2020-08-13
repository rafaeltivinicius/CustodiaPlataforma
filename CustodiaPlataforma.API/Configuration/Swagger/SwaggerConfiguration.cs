using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace CustodiaPlataforma.API.Configuration.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                ConfigurarCabecalhoSwagger(options);
            });

            void ConfigurarCabecalhoSwagger(SwaggerGenOptions options)
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Plataforma Custodia",
                        Version = "v1",
                        Description = "Plataforma de Investimentos",
                        Contact = new OpenApiContact
                        {
                            Name = "Investimentos",
                            Url = new Uri("https://www.investimento.com.br")
                        }
                    });
            }
        }
    }
}

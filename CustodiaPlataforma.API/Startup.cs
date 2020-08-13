using CustodiaPlataforma.API.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CustodiaPlataforma.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguration(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers(options =>
           {
               options.EnableEndpointRouting = false;
           })
            .AddNewtonsoftJson(options =>
            {
                options.UseCamelCasing(processDictionaryKeys: true);
            })
            ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSerilogRequestLogging();

            loggerFactory.AddSerilog();

            app.UseAuthorization();

            app.UseForwardedHeaders(
                new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor }
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plataforma");
            });
        }
    }
}

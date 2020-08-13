using CustodiaPlataforma.Service.Services;
using CustodiaPlataforma.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CustodiaPlataforma.API.Configuration.DependencyInjection
{
    public static class ServicesDI
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<ITesouroDiretoService, TesouroDiretoService>();
            services.AddScoped<IRendaFixaService, RendaFixaService>();
            services.AddScoped<IFundoService, FundoService>();
            services.AddScoped<IPosicaoConsolidadaService, PosicaoConsolidadaService>();
        }
    }
}

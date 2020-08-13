using CustodiaPlataforma.Infra.Repositories;
using CustodiaPlataforma.Infra.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CustodiaPlataforma.API.Configuration.DependencyInjection
{
    public static class RepositoriesDI
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ICacheRepository, RedisRepository>();
            services.AddScoped<ITesouroDiretoRepository, TesouroDiretoRepository>();
            services.AddScoped<IRendaFixaRepository, RendaFixaRepository>();
            services.AddScoped<IFundoRepository, FundoRepository>();
        }
    }
}

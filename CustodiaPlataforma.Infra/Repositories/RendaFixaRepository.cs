using CustodiaPlataforma.DTO.Response.RendaFixa;
using CustodiaPlataforma.Infra.DBConfiguration;
using CustodiaPlataforma.Infra.Models;
using CustodiaPlataforma.Infra.Repositories.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Infra.Repositories
{
    public class RendaFixaRepository : BaseHttpClient, IRendaFixaRepository
    {
        #region Construtores

        public RendaFixaRepository(ILoggerFactory loggerFactory, ApiConfiguration apiConfiguration) : base(loggerFactory.CreateLogger<BaseHttpClient>(), apiConfiguration.RendaFixaPath, useCompression: false, timeOut: 30)
        {
        }

        #endregion Construtores

        public async Task<ExtratoRendaFixaResponseDTO> ObterRendaFixa()
        {
            return await ExecuteGetAsync<ExtratoRendaFixaResponseDTO>("v2/5e3429a33000008c00d96336");
        }
    }
}

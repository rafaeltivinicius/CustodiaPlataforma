using CustodiaPlataforma.DTO.Response.TesouroDireto;
using CustodiaPlataforma.Infra.DBConfiguration;
using CustodiaPlataforma.Infra.Models;
using CustodiaPlataforma.Infra.Repositories.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Infra.Repositories
{
    public class TesouroDiretoRepository : BaseHttpClient, ITesouroDiretoRepository
    {
        #region Construtores

        public TesouroDiretoRepository(ILoggerFactory loggerFactory, ApiConfiguration apiConfiguration) : base(loggerFactory.CreateLogger<BaseHttpClient>(), apiConfiguration.TesouroDiretoPath, useCompression: false, timeOut: 30)
        {
        }

        #endregion Construtores

        public async Task<ExtratoTesouroDiretoResponseDTO> ObterTesouroDireto()
        {
            return await ExecuteGetAsync<ExtratoTesouroDiretoResponseDTO>("v2/5e3428203000006b00d9632a");
        }
    }
}

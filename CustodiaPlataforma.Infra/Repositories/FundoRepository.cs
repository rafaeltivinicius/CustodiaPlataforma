using CustodiaPlataforma.DTO.Response.Fundo;
using CustodiaPlataforma.Infra.DBConfiguration;
using CustodiaPlataforma.Infra.Models;
using CustodiaPlataforma.Infra.Repositories.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Infra.Repositories
{
    public class FundoRepository : BaseHttpClient, IFundoRepository
    {
        #region Construtores

        public FundoRepository(ILoggerFactory loggerFactory, ApiConfiguration apiConfiguration) : base(loggerFactory.CreateLogger<BaseHttpClient>(), apiConfiguration.FundoPath, useCompression: false, timeOut: 30)
        {
        }

        #endregion Construtores

        public async Task<ExtratoFundoResponseDTO> ObterFundo()
        {
            return await ExecuteGetAsync<ExtratoFundoResponseDTO>("v2/5e342ab33000008c00d96342");
        }
    }
}

using CustodiaPlataforma.DTO.Response.Fundo;
using CustodiaPlataforma.Infra.Repositories.Interface;
using CustodiaPlataforma.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services
{
    public class FundoService : IFundoService
    {
        private readonly IFundoRepository _fundoRepository;

        public FundoService(IFundoRepository fundoRepository)
        {
            _fundoRepository = fundoRepository;
        }

        public async Task<ExtratoFundoResponseDTO> ObterFundo()
        {
            return await _fundoRepository.ObterFundo();
        }
    }
}

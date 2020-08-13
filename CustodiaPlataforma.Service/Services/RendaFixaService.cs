using CustodiaPlataforma.DTO.Response.RendaFixa;
using CustodiaPlataforma.Infra.Repositories.Interface;
using CustodiaPlataforma.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services
{
    public class RendaFixaService : IRendaFixaService
    {
        private readonly IRendaFixaRepository _rendaFixaRepository;

        public RendaFixaService(IRendaFixaRepository rendaFixaRepository)
        {
            _rendaFixaRepository = rendaFixaRepository;
        }

        public async Task<ExtratoRendaFixaResponseDTO> ObterRendaFixa()
        {
            return await _rendaFixaRepository.ObterRendaFixa();
        }
    }
}

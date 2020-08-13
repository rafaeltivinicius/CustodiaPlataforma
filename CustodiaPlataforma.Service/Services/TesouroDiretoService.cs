using CustodiaPlataforma.DTO.Response.TesouroDireto;
using CustodiaPlataforma.Infra.Repositories.Interface;
using CustodiaPlataforma.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services
{
    public class TesouroDiretoService : ITesouroDiretoService
    {
        private readonly ITesouroDiretoRepository _tesouroDiretoRepository;

        public TesouroDiretoService(ITesouroDiretoRepository tesouroDiretoRepository)
        {
            _tesouroDiretoRepository = tesouroDiretoRepository;
        }

        public async Task<ExtratoTesouroDiretoResponseDTO> ObterTesouroDireto()
        {
            return await _tesouroDiretoRepository.ObterTesouroDireto();
        }
    }
}

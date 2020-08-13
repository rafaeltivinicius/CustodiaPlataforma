using CustodiaPlataforma.DTO.Response.TesouroDireto;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Infra.Repositories.Interface
{
    public interface ITesouroDiretoRepository
    {
        Task<ExtratoTesouroDiretoResponseDTO> ObterTesouroDireto();
    }
}

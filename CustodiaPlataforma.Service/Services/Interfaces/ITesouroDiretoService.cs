using CustodiaPlataforma.DTO.Response.TesouroDireto;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services.Interfaces
{
    public interface ITesouroDiretoService
    {
        Task<ExtratoTesouroDiretoResponseDTO> ObterTesouroDireto();
    }
}

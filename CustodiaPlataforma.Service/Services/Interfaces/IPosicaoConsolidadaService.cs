using CustodiaPlataforma.DTO.Response.PosicaoConsolidada;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services.Interfaces
{
    public interface IPosicaoConsolidadaService
    {
        Task<ExtratoPosicaoConsolidadaResponseDTO> ObterPosicaoConsolidada();
    }
}

using CustodiaPlataforma.DTO.Response.RendaFixa;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services.Interfaces
{
    public interface IRendaFixaService
    {
        Task<ExtratoRendaFixaResponseDTO> ObterRendaFixa();
    }
}

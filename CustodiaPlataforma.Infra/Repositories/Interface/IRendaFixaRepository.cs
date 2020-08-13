using CustodiaPlataforma.DTO.Response.RendaFixa;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Infra.Repositories.Interface
{
    public interface IRendaFixaRepository
    {
        Task<ExtratoRendaFixaResponseDTO> ObterRendaFixa();
    }
}

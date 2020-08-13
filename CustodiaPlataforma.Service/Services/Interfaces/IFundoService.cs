using CustodiaPlataforma.DTO.Response.Fundo;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services.Interfaces
{
    public interface IFundoService
    {
        Task<ExtratoFundoResponseDTO> ObterFundo();
    }
}

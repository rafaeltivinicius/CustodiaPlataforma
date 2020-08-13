using CustodiaPlataforma.DTO.Response.Fundo;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Infra.Repositories.Interface
{
    public interface IFundoRepository
    {
        Task<ExtratoFundoResponseDTO> ObterFundo();
    }
}

using System;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services.Interfaces
{
    public interface ICacheService
    {
        Task<bool> Gravar<T>(string nomeColecao, T obj, TimeSpan? validoAte = null);

        Task<T> Obter<T>(string nomeColecao);
    }
}

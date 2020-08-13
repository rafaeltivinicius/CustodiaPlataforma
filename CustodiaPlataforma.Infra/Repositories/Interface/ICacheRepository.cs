using System;

namespace CustodiaPlataforma.Infra.Repositories.Interface
{
    public interface ICacheRepository
    {
        bool Gravar<T>(string nomeColecao,T dtoCache, TimeSpan? validoAte = null);

        T Obter<T>(string nomeColecao);
    }
}

using CustodiaPlataforma.Infra.Repositories.Interface;
using CustodiaPlataforma.Service.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public async Task<bool> Gravar<T>(string nomeColecao, T obj, TimeSpan? validoAte = null)
        {
            return await Task.FromResult(_cacheRepository.Gravar<T>(nomeColecao, obj, validoAte));
        }

        public async Task<T> Obter<T>(string nomeColecao)
        {
            return await Task.FromResult(_cacheRepository.Obter<T>(nomeColecao));
        }
    }
}

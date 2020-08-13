using CustodiaPlataforma.Infra.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace CustodiaPlataforma.Infra.Repositories
{
    public class RedisRepository : ICacheRepository
    {
        private readonly ILogger<RedisRepository> _logger;
        private readonly string _server;
        private readonly string _database;
        private readonly ConnectionMultiplexer _connection;

        public RedisRepository(IConfiguration configuration, ILogger<RedisRepository> logger)
        {
            _logger = logger;
            _server = configuration.GetConnectionString("RedisURL");
            _database = configuration.GetValue<string>("Redis:Databases:Default");

            ConnectionMultiplexer.SetFeatureFlag("preventthreadtheft", true);
            _connection = ConnectionMultiplexer.Connect(_server);
        }

        public bool Gravar<T>(string nomeColecao,T dtoCache, TimeSpan? validoAte = null)
        {
            try
            {
                var redisKey = FormatarKey(nomeColecao);

                GetDatabase().StringSet(redisKey, JsonConvert.SerializeObject(dtoCache), validoAte);

                _logger.LogInformation(FormatarMensagemLog($"Inserido {redisKey}", validoAte));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, FormatarMensagemExcecao(ex.Message));
                throw ex;
            }
        }

        public T Obter<T>(string nomeColecao)
        {
            try
            {
                var objectJson = GetDatabase().StringGet(FormatarKey(nomeColecao));

                if (!objectJson.HasValue)
                    return default(T);

                return JsonConvert.DeserializeObject<T>(objectJson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, FormatarMensagemExcecao(ex.Message));
                throw ex;
            }
        }

        #region Metodos Privados
        private IDatabase GetDatabase()
            => _connection.GetDatabase();

        private string FormatarKey(string nomeColecao)
        {
            if (string.IsNullOrEmpty(nomeColecao))
                throw new ArgumentNullException(nameof(nomeColecao));

            return $"{_database}:{nomeColecao}";
        }

        private string FormatarMensagemLog(string message, TimeSpan? validoAte = null)
            => $"Redis {{ URL: \"{_server}\" ; Message: \"{message}\" {(validoAte.HasValue ? $"; DueDate: '{DateTime.UtcNow.Add(validoAte.Value)}' " : string.Empty)}}}";

        private string FormatarMensagemExcecao(string message)
            => $"Redis Exception: {{ URL: \"{_server}\" ; Message: \"{message}\" }}";

        #endregion
    }
}

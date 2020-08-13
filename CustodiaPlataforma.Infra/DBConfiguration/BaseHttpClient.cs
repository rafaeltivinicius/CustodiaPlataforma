using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Extensions.Compression.Client;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Infra.DBConfiguration
{
    public abstract class BaseHttpClient : IDisposable
    {
        private HttpClient _HttpClient { get; set; }
        private string _MediaType { get; set; }
        private bool? _UseCompression { get; set; }
        private double? _TimeOut { get; set; }
        private string _BaseAddress { get; set; }
        protected readonly ILogger<BaseHttpClient> _logger;

        #region Constantes

        private const string _DefaultMediaType = MediaTypeNames.Application.Json;
        private const bool _DefaultUseCompression = true;
        private const double _DefaultTimeOut = 15;

        #endregion Constantes

        #region Propriedades

        protected string MediaType
        {
            get
            {
                if (_MediaType == null)
                    _MediaType = _DefaultMediaType;

                return _MediaType;
            }
            set
            {
                this._MediaType = value;
                ConfigureHttpClient();
            }
        }

        protected bool UseCompression
        {
            get
            {
                if (!_UseCompression.HasValue)
                {
                    _UseCompression = _DefaultUseCompression;
                }
                return _UseCompression.Value;
            }
            set
            {
                this._UseCompression = value;
                ConfigureHttpClient();
            }
        }

        protected double TimeOut
        {
            get
            {
                if (!_TimeOut.HasValue)
                {
                    _TimeOut = _DefaultTimeOut;
                }
                return _TimeOut.Value;
            }
            set
            {
                this._TimeOut = value;
                ConfigureHttpClient();
            }
        }

        #endregion Propriedades

        #region Construtores

        public BaseHttpClient(ILogger<BaseHttpClient> logger, string baseAddress, string mediaType = _DefaultMediaType, bool useCompression = _DefaultUseCompression, double timeOut = _DefaultTimeOut)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException("Endereço base do HttpClient não foi definido no construtor!", "baseAddress");

            _logger = logger;
            this._BaseAddress = baseAddress;
            this._MediaType = mediaType;
            this._UseCompression = useCompression;
            this._TimeOut = timeOut;

            ConfigureHttpClient();
        }

        #endregion Construtores

        #region [ Metodos Publicos ]

        public async Task<TOut> ExecuteGetAsync<TOut>(string pathExecute, bool ensureSuccessResponse = true)
        {
            Stopwatch elapsed = new Stopwatch();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.Timeout = TimeSpan.FromSeconds(this.TimeOut);
                    httpClient.BaseAddress = new Uri(this._BaseAddress);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.MediaType));

                    elapsed.Start();
                    var response = await httpClient.GetAsync(pathExecute);
                    elapsed.Stop();

                    if (ensureSuccessResponse)
                        response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                    var resultObject = JsonConvert.DeserializeObject<TOut>(result);

                    return resultObject;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, FormatarExceptionLog(HttpMethod.Get, ex.Message, pathExecute));
                throw ex;
            }
            catch (OperationCanceledException ex)
            {
                elapsed.Stop();
                _logger.LogError(ex, FormatarExceptionLog(HttpMethod.Get, ex.Message, pathExecute));
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<TOut> ExecuteGetUrlReadyAsync<TOut>(string url)
        {
            Stopwatch elapsed = new Stopwatch();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    elapsed.Start();

                    var content = await httpClient.GetStringAsync(url);

                    elapsed.Stop();

                    return JsonConvert.DeserializeObject<TOut>(content);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, FormatarExceptionLog(HttpMethod.Get, ex.Message, url));
                throw ex;
            }
            catch (OperationCanceledException ex)
            {
                elapsed.Stop();
                _logger.LogError(ex, FormatarExceptionLog(HttpMethod.Get, ex.Message, url));
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, FormatarExceptionLog(HttpMethod.Get, ex.Message, url));
                throw new Exception("Erro ao executar GET " + DateTime.Now.ToString("yyyyMMddHHmmss"), ex);
            }
        }

        #endregion [ Metodos Publicos ]

        #region [ Metodos Private ]

        private HttpClient ConfigureHttpClient()
        {
            this._HttpClient = new HttpClient();
            _HttpClient.DefaultRequestHeaders.Clear();

            _HttpClient.Timeout = TimeSpan.FromSeconds(this.TimeOut);
            _HttpClient.BaseAddress = new Uri(this._BaseAddress);

            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.MediaType));

            return _HttpClient;
        }

        private volatile bool _isDisposed;

        public virtual void Dispose()
        {
            try
            {
                if (!this._isDisposed)
                {
                    this._isDisposed = true;
                    lock (this._HttpClient)
                    {
                        this._HttpClient.Dispose();
                    }
                    GC.SuppressFinalize(this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string FormatarExceptionLog(HttpMethod method, string message, string url)
            => $"External Service {{ Method: {method} ; URL: {_BaseAddress}/{url} ; Exception Message: {message} }}";

        #endregion [ Metodos Private ]
    }
}
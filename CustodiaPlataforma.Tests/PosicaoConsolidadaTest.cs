using CustodiaPlataforma.Tests.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using Xunit;

namespace CustodiaPlataforma.Tests
{
    public class PosicaoConsolidadaTest 
    {
        public readonly HttpClient client;

        public readonly ConfigurationHelper configurationHelper;

        public PosicaoConsolidadaTest()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
            configurationHelper = ConfigurationHelper.Build();
            client.BaseAddress = new Uri(configurationHelper.BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }

        [Fact]
        public async Task PosicaoConsolidada()
        {
            var resposta = await client.GetAsync($"v1/PosicaoConsolidada");

            Assert.True(resposta.IsSuccessStatusCode);
        }
    }
}

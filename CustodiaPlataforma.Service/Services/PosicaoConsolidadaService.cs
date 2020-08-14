using CustodiaPlataforma.DTO.Enums;
using CustodiaPlataforma.DTO.Response.PosicaoConsolidada;
using CustodiaPlataforma.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustodiaPlataforma.Service.Services
{
    public class PosicaoConsolidadaService : IPosicaoConsolidadaService
    {
        private readonly ITesouroDiretoService _tesouroDiretoService;
        private readonly IRendaFixaService _rendaFixaService;
        private readonly IFundoService _fundoService;
        private readonly ICacheService _cacheService;

        public PosicaoConsolidadaService(ITesouroDiretoService tesouroDiretoService, IRendaFixaService rendaFixaService, IFundoService fundoService,
            ICacheService cacheService)
        {
            _tesouroDiretoService = tesouroDiretoService;
            _rendaFixaService = rendaFixaService;
            _fundoService = fundoService;
            _cacheService = cacheService;
        }

        #region Metodos Publicos

        public async Task<ExtratoPosicaoConsolidadaResponseDTO> ObterPosicaoConsolidada()
        {
            return (await _cacheService
                   .Obter<ExtratoPosicaoConsolidadaResponseDTO>("posicaoConsolidada"))
                   ?? await ObterPosicaoConsolidadaAPI();
        }

        public async Task<ExtratoPosicaoConsolidadaResponseDTO> ObterPosicaoConsolidadaAPI()
        {
            var extratoPosicao = new ExtratoPosicaoConsolidadaResponseDTO();

            extratoPosicao.Investimentos.AddRange(await ObterTesouroDiretoPosicaoConsolidada());

            extratoPosicao.Investimentos.AddRange(await ObterRendaFixaPosicaoConsolidada());

            extratoPosicao.Investimentos.AddRange(await ObterFundoPosicaoConsolidada());

            extratoPosicao.ValorTotal = extratoPosicao.Investimentos.Select(x => x.ValorResgate).Sum();

            var registrado = await _cacheService.Gravar("posicaoConsolidada", extratoPosicao, TimeSpan.FromHours(24));

            return extratoPosicao;
        }

        public async Task<IEnumerable<PosicaoConsolidadaResponseDTO>> ObterFundoPosicaoConsolidada()
        {
            var extratoFundo = await _fundoService.ObterFundo();

            return extratoFundo.Fundos.Select(x => new PosicaoConsolidadaResponseDTO
            {
                Nome = x.Nome,
                ValorInvestido = x.CapitalInvestido,
                ValorTotal = x.ValorAtual,
                Vencimento = x.DataResgate,
                Ir = ObterValorIR(x.ValorAtual, x.CapitalInvestido, EProduto.Fundo),
                ValorResgate = ObterValorResgate(x.DataCompra, x.DataResgate, x.ValorAtual)
            });
        }

        public async Task<IEnumerable<PosicaoConsolidadaResponseDTO>> ObterRendaFixaPosicaoConsolidada()
        {
            var extratoRendaFixa = await _rendaFixaService.ObterRendaFixa();

            return extratoRendaFixa.Lcis.Select(x => new PosicaoConsolidadaResponseDTO
            {
                Nome = x.Nome,
                ValorInvestido = x.CapitalInvestido,
                ValorTotal = x.CapitalAtual,
                Vencimento = x.Vencimento,
                Ir = ObterValorIR(x.CapitalAtual, x.CapitalInvestido, EProduto.RendaFixa),
                ValorResgate = ObterValorResgate(x.DataOperacao, x.Vencimento, x.CapitalAtual)
            });
        }

        public async Task<IEnumerable<PosicaoConsolidadaResponseDTO>> ObterTesouroDiretoPosicaoConsolidada()
        {
            var extratoTesousoDireto = await _tesouroDiretoService.ObterTesouroDireto();

            return extratoTesousoDireto.Tds.Select(x => new PosicaoConsolidadaResponseDTO
            {
                Nome = x.Nome,
                ValorInvestido = x.ValorInvestido,
                ValorTotal = x.ValorTotal,
                Vencimento = x.Vencimento,
                Ir = ObterValorIR(x.ValorTotal, x.ValorInvestido, EProduto.TesouroDireto),
                ValorResgate = ObterValorResgate(x.DataDeCompra, x.Vencimento, x.ValorTotal)
            });
        }

        #endregion

        #region Metodos Privados

        private decimal ObterValorIR(decimal valorTotal, decimal valorInvestido, EProduto produto)
        {
            switch (produto)
            {
                case EProduto.TesouroDireto:
                    return ((valorTotal - valorInvestido) * 10 / 100);
                case EProduto.RendaFixa:
                    return ((valorTotal - valorInvestido) * 5 / 100);
                case EProduto.Fundo:
                    return ((valorTotal - valorInvestido) * 15 / 100);
                default: return 0;
            }
        }

        private decimal ObterValorResgate(DateTime dataCompra, DateTime dataVencimento, decimal valorTotal)
        {
            var totalMesesCustodia = ObterMesesCustodia(dataVencimento, dataCompra);
            var mesesCustodiaFaltante = ObterMesesCustodia(dataVencimento, DateTime.Now);

            if (mesesCustodiaFaltante <= 3)
                return valorTotal - (valorTotal * 0.06m);

            if ((totalMesesCustodia / 2) > mesesCustodiaFaltante)
                return valorTotal - (valorTotal * 0.15m);

            return valorTotal - (valorTotal * 0.30m);
        }

        private int ObterMesesCustodia(DateTime dataVenciamento, DateTime dataRetirada)
                => Math.Abs((dataVenciamento.Month - dataRetirada.Month) + 12 * (dataVenciamento.Year - dataRetirada.Year));

        #endregion
    }
}

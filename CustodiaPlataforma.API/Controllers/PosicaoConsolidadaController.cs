using CustodiaPlataforma.DTO.Response.PosicaoConsolidada;
using CustodiaPlataforma.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CustodiaPlataforma.API.Controllers
{
    [ApiController, Route("")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PosicaoConsolidadaController : ControllerBase
    {
        private readonly ILogger<PosicaoConsolidadaController> _logger;
        private readonly IPosicaoConsolidadaService _posicaoConsolidadaService;

        public PosicaoConsolidadaController(ILogger<PosicaoConsolidadaController> logger, IPosicaoConsolidadaService posicaoConsolidadaService)
        {
            _logger = logger;
            _posicaoConsolidadaService = posicaoConsolidadaService;
        }

        #region swagger doc

        /// <summary>
        /// Posição Consolidada
        /// </summary>
        /// <param name="dto">Extrato Posição Consolidada</param>
        /// <response code="200">Se a solicitação foi aceita</response>
        /// <response code="500">Erro ao executar solicitação</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExtratoPosicaoConsolidadaResponseDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]

        #endregion swagger doc
        [HttpGet("api/v1/[controller]/")]
        public async Task<IActionResult> ObterTesouroDireto()
        {
            return Ok(await _posicaoConsolidadaService.ObterValorTotalInvestido());
        }
    }
}

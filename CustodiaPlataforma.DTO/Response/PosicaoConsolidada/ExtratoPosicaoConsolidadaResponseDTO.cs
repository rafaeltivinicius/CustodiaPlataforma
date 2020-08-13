using System.Collections.Generic;

namespace CustodiaPlataforma.DTO.Response.PosicaoConsolidada
{
    public class ExtratoPosicaoConsolidadaResponseDTO
    {
        public decimal ValorTotal { get; set; }
        public List<PosicaoConsolidadaResponseDTO> Investimentos { get; set; }

        public ExtratoPosicaoConsolidadaResponseDTO()
        {
            Investimentos = new List<PosicaoConsolidadaResponseDTO>();
        }
    }
}

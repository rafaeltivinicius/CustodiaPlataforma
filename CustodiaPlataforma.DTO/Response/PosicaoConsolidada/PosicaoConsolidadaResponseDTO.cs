using System;

namespace CustodiaPlataforma.DTO.Response.PosicaoConsolidada
{
    public class PosicaoConsolidadaResponseDTO
    {
        public string Nome { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Ir { get; set; }
        public decimal ValorResgate { get; set; }
    }
}

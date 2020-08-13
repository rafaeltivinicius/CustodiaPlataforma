using System;

namespace CustodiaPlataforma.DTO.Response.RendaFixa
{
    public class RendaFixaResponseDTO
    {
        public decimal CapitalInvestido { get; set; }
        public decimal CapitalAtual { get; set; }
        public double Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Iof { get; set; }
        public decimal OutrasTaxas { get; set; }
        public decimal Taxas { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool GuarantidoFGC { get; set; }
        public DateTime DataOperacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool Primario { get; set; }
    }
}

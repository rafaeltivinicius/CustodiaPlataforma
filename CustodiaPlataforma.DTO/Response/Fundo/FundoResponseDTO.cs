using System;

namespace CustodiaPlataforma.DTO.Response.Fundo
{
    public class FundoResponseDTO
    {
        public decimal CapitalInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime DataResgate { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal Iof { get; set; }
        public string Nome { get; set; }
        public decimal totalTaxas { get; set; }
        public double Quantity { get; set; }
    }
}

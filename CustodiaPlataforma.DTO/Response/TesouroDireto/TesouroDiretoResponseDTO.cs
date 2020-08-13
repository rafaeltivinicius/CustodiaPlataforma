﻿using System;

namespace CustodiaPlataforma.DTO.Response.TesouroDireto
{
    public class TesouroDiretoResponseDTO
    {
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataDeCompra { get; set; }
        public decimal Iof { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
    }
}

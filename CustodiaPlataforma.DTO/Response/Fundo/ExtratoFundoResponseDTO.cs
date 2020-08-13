using CustodiaPlataforma.DTO.Response.PosicaoConsolidada;
using System;
using System.Collections.Generic;

namespace CustodiaPlataforma.DTO.Response.Fundo
{
    public class ExtratoFundoResponseDTO
    {
        public List<FundoResponseDTO> Fundos { get; set; }

        public ExtratoFundoResponseDTO()
        {
            Fundos = new List<FundoResponseDTO>();
        }

    }
}

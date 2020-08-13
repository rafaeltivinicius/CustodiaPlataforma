using System.Collections.Generic;

namespace CustodiaPlataforma.DTO.Response.RendaFixa
{
    public class ExtratoRendaFixaResponseDTO
    {
        public List<RendaFixaResponseDTO> Lcis { get; set; }

        public ExtratoRendaFixaResponseDTO()
        {
            Lcis = new List<RendaFixaResponseDTO>();
        }
    }
}

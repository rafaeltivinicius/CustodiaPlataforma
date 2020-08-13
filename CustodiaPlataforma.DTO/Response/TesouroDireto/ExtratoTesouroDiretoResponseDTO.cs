using System.Collections.Generic;

namespace CustodiaPlataforma.DTO.Response.TesouroDireto
{
    public class ExtratoTesouroDiretoResponseDTO
    {
        public List<TesouroDiretoResponseDTO> Tds { get; set; }

        public ExtratoTesouroDiretoResponseDTO()
        {
            Tds = new List<TesouroDiretoResponseDTO>();
        }
    }
}

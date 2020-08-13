using System;
using System.Collections.Generic;
using System.Text;

namespace CustodiaPlataforma.Infra.Models
{
    public class ApiConfiguration
    {
        public string BasePath { get; set; }
        public string TesouroDiretoPath { get; set; }
        public string RendaFixaPath { get; set; }
        public string FundoPath { get; set; }
    }
}

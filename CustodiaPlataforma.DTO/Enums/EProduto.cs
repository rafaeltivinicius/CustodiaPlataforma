using System.ComponentModel;

namespace CustodiaPlataforma.DTO.Enums
{
    public enum EProduto
    {
        [Description("TESOURO_DIRETO")]
        TesouroDireto,
        [Description("RENDA_FIXA")]
        RendaFixa,
        [Description("FUNDO")]
        Fundo,
    }
}

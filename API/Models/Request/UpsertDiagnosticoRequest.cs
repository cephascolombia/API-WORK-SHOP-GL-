using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class UpsertDiagnosticoRequest
    {
        [JsonPropertyName("diag_preliminar")]
        public string? DiagPreliminar { get; set; }

        [JsonPropertyName("diag_tecnico")]
        public string? DiagTecnico { get; set; }

        [JsonPropertyName("solucion")]
        public string? Solucion { get; set; }

        [JsonPropertyName("usuario")]
        public string? Usuario { get; set; }
    }
}

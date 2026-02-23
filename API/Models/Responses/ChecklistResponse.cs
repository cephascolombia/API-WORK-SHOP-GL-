using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class ChecklistResponse
    {
        [JsonPropertyName("cabecera")]
        public RevisionResponse? Cabecera { get; set; }

        [JsonPropertyName("subsistemas")]
        public List<ChecklistSubsistemaResponse> Subsistemas { get; set; } = new List<ChecklistSubsistemaResponse>();
    }

    public class ChecklistSubsistemaResponse
    {
        [JsonPropertyName("nombre_subsistema")]
        public string? NombreSubsistema { get; set; }

        [JsonPropertyName("componentes")]
        public List<ChecklistComponenteResponse> Componentes { get; set; } = new List<ChecklistComponenteResponse>();
    }

    public class ChecklistComponenteResponse
    {
        [JsonPropertyName("componente")]
        public string? Componente { get; set; }

        [JsonPropertyName("falla")]
        public bool Falla { get; set; }

        [JsonPropertyName("observacion_detalle")]
        public string? ObservacionDetalle { get; set; }
    }
}

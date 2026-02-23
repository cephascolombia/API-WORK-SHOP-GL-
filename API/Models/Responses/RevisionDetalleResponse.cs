using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class RevisionDetalleResponse : RevisionResponse
    {
        [JsonPropertyName("item")]
        public string? Item { get; set; }

        [JsonPropertyName("falla")]
        public bool Falla { get; set; }

        [JsonPropertyName("observacion_detalle")]
        public string? ObservacionDetalle { get; set; }

        [JsonPropertyName("nombre_subsistema")]
        public string? NomSubSistema { get; set; }
    }
}

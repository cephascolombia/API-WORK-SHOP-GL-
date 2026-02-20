using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class ComponenteResponse
    {
        [JsonPropertyName("delmrk")]
        public string? Delmrk { get; set; }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("cod_sistema")]
        public string? CodSistema { get; set; }

        [JsonPropertyName("nombre_sistema")]
        public string? nomSistema { get; set; }

        [JsonPropertyName("nombre_sub_sistema")]
        public string? nomSubSistema { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("cod_sub_sistema")]
        public string? CodSubSistema { get; set; }
    }
}

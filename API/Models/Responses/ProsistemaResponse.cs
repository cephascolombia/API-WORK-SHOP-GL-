using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class ProsistemaResponse
    {
        [JsonPropertyName("delmrk")]
        public string Delmrk { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("nombre_componente")]
        public string Nombre { get; set; }

        [JsonPropertyName("codigo_sistema")]
        public string CodSistema { get; set; }

        [JsonPropertyName("nombre_sistema")]
        public string NomSistema { get; set; }

        [JsonPropertyName("codigo_sub_sistema")]
        public string CodSubSistema { get; set; }

        [JsonPropertyName("nombre_sub_sistema")]
        public string NomSubSistema { get; set; }
    }
}

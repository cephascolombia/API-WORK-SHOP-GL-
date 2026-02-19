using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class SistemaSimpleResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("nombre_sistema")]
        public string Nombre { get; set; }

        [JsonPropertyName("codigo_sistema")]
        public string CodSistema { get; set; }
    }
}

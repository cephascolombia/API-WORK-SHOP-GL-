using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class MarcaResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo_marca { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre_marca { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class ClaseResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo_clase { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre_clase { get; set; }
    }
}

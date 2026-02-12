using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class ColorResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo_color { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre_color { get; set; }
    }
}

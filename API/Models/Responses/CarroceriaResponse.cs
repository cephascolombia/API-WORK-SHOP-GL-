using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class CarroceriaResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo_carroceria { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre_carroceria { get; set; }
    }
}

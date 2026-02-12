using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class CiudadResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo_ciudad { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre_ciudad { get; set; }
    }
}

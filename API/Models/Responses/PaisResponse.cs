using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class PaisResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo_pais { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre_pais { get; set; }
    }
}

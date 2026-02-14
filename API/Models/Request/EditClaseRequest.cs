using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class EditClaseRequest
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }
}

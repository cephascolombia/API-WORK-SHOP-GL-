using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class EditColorRequest
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }
}

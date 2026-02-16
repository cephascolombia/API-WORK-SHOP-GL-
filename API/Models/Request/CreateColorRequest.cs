using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class CreateColorRequest
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class CreateClaseRequest
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }
}

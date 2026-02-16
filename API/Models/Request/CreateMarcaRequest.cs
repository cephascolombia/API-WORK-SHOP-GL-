using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class CreateMarcaRequest
    {
        [JsonPropertyName("nombre")]
        public string nomMarV { get; set; }
    }
}

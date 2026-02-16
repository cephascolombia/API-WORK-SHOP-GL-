using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class EditMarcaRequest
    {
        [JsonPropertyName("codigo")]
        public string codMarV { get; set; }
        [JsonPropertyName("nombre")]
        public string nomMarV { get; set; }
    }
}

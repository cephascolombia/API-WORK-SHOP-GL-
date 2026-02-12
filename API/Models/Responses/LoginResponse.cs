using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class VehiculoResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("placa")]
        public string Placa { get; set; }

        [JsonPropertyName("modelo")]
        public string Modelo { get; set; }

        [JsonPropertyName("codigo_cliente")]
        public string Codigo_cliente { get; set; }

        [JsonPropertyName("nombre_cliente")]
        public string Nombre_cliente { get; set; }

        [JsonPropertyName("codigo_marca")]
        public string Codigo_marca { get; set; }

        [JsonPropertyName("nombre_marca")]
        public string Nombre_marca { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class EditVehiculoRequest
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [Required]
        [JsonPropertyName("placa")]
        public string Placa { get; set; }

        [Required]
        [JsonPropertyName("modelo")]
        public string Modelo { get; set; }

        [JsonPropertyName("codigo_cliente")]
        public string Codigo_cliente { get; set; }

        [Required]
        [JsonPropertyName("codigo_marca")]
        public string Codigo_marca { get; set; }

        [JsonPropertyName("codigo_color")]
        public string Codigo_color { get; set; }

        [JsonPropertyName("codigo_carroceria")]
        public string Codigo_carroceria { get; set; }

        [JsonPropertyName("codigo_clase")]
        public string Codigo_clase { get; set; }

        [JsonPropertyName("cilindraje")]
        public int Cilindraje { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class EditTecnicoRequest : CreateTecnicoRequest
    {
        [JsonPropertyName("codigo_tecnico")]
        public string CodigoTecnico { get; set; }
    }
}

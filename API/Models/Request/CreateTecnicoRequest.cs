using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class CreateTecnicoRequest
    {
        [JsonPropertyName("nit")]
        public string nit { get; set; }

        [JsonPropertyName("tipo_documento")]
        public string tipoDocumento { get; set; }

        [JsonPropertyName("tipo_persona")]
        public int tipoPersona { get; set; }

        [JsonPropertyName("primer_nombre")]
        public string primerNombre { get; set; }

        [JsonPropertyName("segundo_nombre")]
        public string segundoNombre { get; set; }

        [JsonPropertyName("primer_apellido")]
        public string primerApellido { get; set; }

        [JsonPropertyName("segundo_apellido")]
        public string segundoApellido { get; set; }

        [JsonPropertyName("direccion")]
        public string direccion { get; set; }

        [JsonPropertyName("telefono")]
        public string telefono { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("celular")]
        public string celular { get; set; }

        [JsonPropertyName("codigo_ciudad")]
        public string codigoCiudad { get; set; }

        [JsonPropertyName("nombre_ciudad")]
        public string nombreCiudad { get; set; }

        [JsonPropertyName("codigo_pais")]
        public string codigoPais { get; set; }

        [JsonPropertyName("nombre_pais")]
        public string nombrePais { get; set; }
    }
}

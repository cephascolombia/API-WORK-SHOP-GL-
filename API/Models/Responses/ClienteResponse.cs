using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class ClienteResponse
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("nit")]
        public string Nit { get; set; }

        [JsonPropertyName("tipo_documento")]
        public string Tipo_documento { get; set; }

        [JsonPropertyName("nombre_completo")]
        public string Nombre_completo { get; set; }

        [JsonPropertyName("primer_nombre")]
        public string Primer_nombre { get; set; }

        [JsonPropertyName("segundo_nombre")]
        public string Segundo_nombre { get; set; }

        [JsonPropertyName("primer_apellido")]
        public string Primer_apellido { get; set; }

        [JsonPropertyName("segundo_apellido")]
        public string Segundo_apellido { get; set; }

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("celular")]
        public string Celular { get; set; }

        [JsonPropertyName("codigo_ciudad")]
        public string Codigo_ciudad { get; set; }

        [JsonPropertyName("nombre_ciudad")]
        public string Nombre_ciudad { get; set; }

        [JsonPropertyName("codigo_pais")]
        public string Codigo_pais { get; set; }

        [JsonPropertyName("nombre_pais")]
        public string Nombre_pais { get; set; }

        [JsonPropertyName("fecha_registro")]
        public DateTime Fecha_registro { get; set; }
    }
}

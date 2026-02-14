using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class EditClienteRequest
    {
        [Required]
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [JsonPropertyName("nit")]
        public string Nit { get; set; }

        [Required]
        [StringLength(2)]
        [JsonPropertyName("tipo_documento")]
        public string TipoDocumento { get; set; }

        [Required]
        [JsonPropertyName("tipo_persona")]
        public int TipoPersona { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("primer_nombre")]
        public string PrimerNombre { get; set; }

        [StringLength(30)]
        [JsonPropertyName("segundo_nombre")]
        public string? SegundoNombre { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("primer_apellido")]
        public string PrimerApellido { get; set; }

        [StringLength(30)]
        [JsonPropertyName("segundo_apellido")]
        public string? SegundoApellido { get; set; }

        [Required]
        [StringLength(200)]
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(200)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [StringLength(50)]
        [JsonPropertyName("celular")]
        public string Celular { get; set; }

        [Required]
        [StringLength(5)]
        [JsonPropertyName("codigo_ciudad")]
        public string CodigoCiudad { get; set; }

        [Required]
        [StringLength(4)]
        [JsonPropertyName("codigo_pais")]
        public string CodigoPais { get; set; }
    }
}

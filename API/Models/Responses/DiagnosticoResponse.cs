using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class DiagnosticoResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id_ingreso")]
        public string? IdIngreso { get; set; }

        [JsonPropertyName("placa")]
        public string? Placa { get; set; }

        [JsonPropertyName("cliente")]
        public string? Cliente { get; set; }

        [JsonPropertyName("tecnico")]
        public string? Tecnico { get; set; }

        [JsonPropertyName("diag_preliminar")]
        public string? DiagPreliminar { get; set; }

        [JsonPropertyName("diag_tecnico")]
        public string? DiagTecnico { get; set; }

        [JsonPropertyName("solucion")]
        public string? Solucion { get; set; }

        [JsonPropertyName("nombre_usuario")]
        public string? NombreUsuario { get; set; }

        [JsonPropertyName("fecha_ingreso")]
        public string? FechaIngreso { get; set; }

        [JsonPropertyName("hora_ingreso")]
        public string? HoraIngreso { get; set; }
    }
}

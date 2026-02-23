using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class RevisionResponse
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("nro_orden")]
        public string? NroOrden { get; set; }

        [JsonPropertyName("nro_cotiza")]
        public string? NroCotiza { get; set; }

        [JsonPropertyName("fecha")]
        public string? Fecha { get; set; }

        [JsonPropertyName("observaciones")]
        public string? Observaciones { get; set; }

        [JsonPropertyName("fecha_ingreso")]
        public string? FechaIngreso { get; set; }

        [JsonPropertyName("hora_ingreso")]
        public string? HoraIngreso { get; set; }

        [JsonPropertyName("fecha_salida")]
        public string? FechaSalida { get; set; }

        [JsonPropertyName("hora_salida")]
        public string? HoraSalida { get; set; }

        [JsonPropertyName("placa")]
        public string? Placa { get; set; }

        [JsonPropertyName("cliente")]
        public string? Cliente { get; set; }

        [JsonPropertyName("nombre_cliente")]
        public string? NombreCliente { get; set; }

        [JsonPropertyName("tipo_trabajo")]
        public string? TipoTrabajo { get; set; }

        [JsonPropertyName("nombre_tipo_trabajo")]
        public string? NomTipoTrabajo { get; set; }

        [JsonPropertyName("nivel_combustible")]
        public string? NivelCombustible { get; set; }

        [JsonPropertyName("kilometraje")]
        public decimal Kilometraje { get; set; }

        [JsonPropertyName("tecnico")]
        public string? Tecnico { get; set; }

        [JsonPropertyName("nombre_tecnico")]
        public string? NombreTecnico { get; set; }

        [JsonPropertyName("fecha_server")]
        public string? FechaServer { get; set; }

        [JsonPropertyName("estacion")]
        public string? Estacion { get; set; }

        [JsonPropertyName("usuario")]
        public string? Usuario { get; set; }

        [JsonPropertyName("nombre_usuario")]
        public string? NombreUsuario { get; set; }

        [JsonPropertyName("estado")]
        public int Estado { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id_sistema")]
        public string? IdSistema { get; set; }

        [JsonPropertyName("solucion")]
        public string? Solucion { get; set; }
    }
}

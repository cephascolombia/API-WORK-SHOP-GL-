using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Request
{
    public class CreateRevisionRequest
    {
        [JsonPropertyName("nro_orden")]
        public string? NroOrden { get; set; }

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

        [JsonPropertyName("tipo_trabajo")]
        public string? TipoTrabajo { get; set; }

        [JsonPropertyName("nivel_combustible")]
        public string? NivelCombustible { get; set; }

        [JsonPropertyName("kilometraje")]
        public decimal Kilometraje { get; set; }

        [JsonPropertyName("tecnico")]
        public string? Tecnico { get; set; }

        [JsonPropertyName("usuario")]
        public string? Usuario { get; set; }

        [JsonPropertyName("estado")]
        public int Estado { get; set; }

        [JsonPropertyName("id_sistema")]
        public string? IdSistema { get; set; }

        [JsonPropertyName("detalles")]
        public List<ItemTallerRequest> Detalles { get; set; } = new List<ItemTallerRequest>();
    }

    public class ItemTallerRequest
    {
        [JsonPropertyName("id_item_taller")]
        public int IdItemTaller { get; set; }

        [JsonPropertyName("falla")]
        public bool Falla { get; set; }

        [JsonPropertyName("observacion")]
        public string? Observacion { get; set; }

        [JsonPropertyName("posicion")]
        public string? Posicion { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace WorkShopGL.API.Models.Responses
{
    public class SistemaSimpleResponse
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("cod_sistema")]
        public string? CodSistema { get; set; }

        [JsonPropertyName("total_registros")]
        public int TotalRegistros { get; set; }

        [JsonPropertyName("total_paginas")]
        public int TotalPaginas { get; set; }
    }
}

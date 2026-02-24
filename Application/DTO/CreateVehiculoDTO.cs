namespace WorkShopGL.Application.DTO
{
    public class CreateVehiculoDTO
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string? Codigo_cliente { get; set; } = "";
        public string Codigo_marca { get; set; }
        public string? Codigo_color { get; set; } = "";
        public string? Codigo_carroceria { get; set; } = "";
        public string? Codigo_clase { get; set; } = "";
        public int Cilindraje { get; set; }
    }
}

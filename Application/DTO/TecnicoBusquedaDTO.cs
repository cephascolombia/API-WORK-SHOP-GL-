namespace WorkShopGL.Application.DTO
{
    public class TecnicoBusquedaDTO
    {
        public string Cedula { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
    }
}

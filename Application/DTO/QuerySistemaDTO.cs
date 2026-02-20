namespace WorkShopGL.Application.DTO
{
    public class QuerySistemaDTO
    {
        public string? Busqueda { get; set; }
        public int Pagina { get; set; } = 1;
        public int RegistrosXPagina { get; set; } = 10;
    }
}

namespace WorkShopGL.Application.DTO
{
    public class QueryTecnicoDTO
    {
        public string? Busqueda { get; set; }
        public int Pagina { get; set; } = 1;
        public int RegistrosXPag { get; set; } = 10;
    }
}

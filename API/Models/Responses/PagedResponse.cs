namespace WorkShopGL.API.Models.Responses
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }
        public int RegistrosXPagina { get; set; }
    }
}

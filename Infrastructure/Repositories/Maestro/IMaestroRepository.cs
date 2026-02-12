using WorkShopGL.Application.DTO;

namespace WorkShopGL.Infrastructure.Repositories.Maestro
{
    public interface IMaestroRepository
    {
        Task<IEnumerable<QueryPaisDTO>?> GetPaises();
        Task<IEnumerable<QueryCiudadDTO>?> GetCiudades();
        Task<IEnumerable<QueryColorDTO>?> GetColores();
        Task<IEnumerable<QueryClaseDTO>?> GetClases();
        Task<IEnumerable<QueryCarroceriaDTO>?> GetCarrocerias();
        Task<IEnumerable<QueryMarcaDTO>?> GetMarcas();
    }
}

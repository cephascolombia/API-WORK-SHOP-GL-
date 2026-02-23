using WorkShopGL.API.Models.Responses;

namespace WorkShopGL.Infrastructure.Repositories.Prosistema
{
    public interface IProsistemaRepository
    {
        Task<IEnumerable<SistemaSimpleResponse>> GetSistemasAsync();
        Task<IEnumerable<ProsistemaResponse>> GetComponentesBySistemaAsync(string codSistema);
        Task<IEnumerable<ProsistemaResponse>> BuscarComponentesAsync(string criterio);
    }
}

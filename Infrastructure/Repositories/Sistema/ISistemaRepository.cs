using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;

namespace WorkShopGL.Infrastructure.Repositories.Sistema
{
    public interface ISistemaRepository
    {
        Task<PagedResult<SistemaSimpleResponse>> GetSistemasAsync(QuerySistemaDTO query);
        Task<IEnumerable<ComponenteResponse>> GetComponentesBySistemaAsync(string codSistema);
        Task<IEnumerable<ComponenteResponse>> BuscarComponentesAsync(string criterio);
    }
}

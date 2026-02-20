using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Sistema
{
    public interface ISistemaService
    {
        Task<PagedResult<SistemaSimpleResponse>> GetSistemasAsync(QuerySistemaDTO query);
        Task<IEnumerable<ComponenteResponse>> GetComponentesBySistemaAsync(string codSistema);
        Task<IEnumerable<ComponenteResponse>> BuscarComponentesAsync(string criterio);
    }
}

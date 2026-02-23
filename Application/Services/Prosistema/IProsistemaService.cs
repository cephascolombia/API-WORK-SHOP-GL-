using WorkShopGL.API.Models.Responses;

namespace WorkShopGL.Application.Services.Prosistema
{
    public interface IProsistemaService
    {
        Task<IEnumerable<SistemaSimpleResponse>> GetSistemasAsync();
        Task<IEnumerable<ProsistemaResponse>> GetComponentesBySistemaAsync(string codSistema);
        Task<IEnumerable<ProsistemaResponse>> BuscarComponentesAsync(string criterio);
    }
}

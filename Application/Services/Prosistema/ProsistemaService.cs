using WorkShopGL.API.Models.Responses;
using WorkShopGL.Infrastructure.Repositories.Prosistema; 

namespace WorkShopGL.Application.Services.Prosistema;

public class ProsistemaService(IProsistemaRepository repository) : IProsistemaService
{
    public async Task<IEnumerable<SistemaSimpleResponse>> GetSistemasAsync()
        => await repository.GetSistemasAsync();

    public async Task<IEnumerable<ProsistemaResponse>> GetComponentesBySistemaAsync(string codSistema)
        => await repository.GetComponentesBySistemaAsync(codSistema);

    public async Task<IEnumerable<ProsistemaResponse>> BuscarComponentesAsync(string criterio)
        => await repository.BuscarComponentesAsync(criterio);
}
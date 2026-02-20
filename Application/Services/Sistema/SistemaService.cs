using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Sistema;

namespace WorkShopGL.Application.Services.Sistema
{
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaRepository _repository;

        public SistemaService(ISistemaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<SistemaSimpleResponse>> GetSistemasAsync(QuerySistemaDTO query)
            => await _repository.GetSistemasAsync(query);

        public async Task<IEnumerable<ComponenteResponse>> GetComponentesBySistemaAsync(string codSistema)
            => await _repository.GetComponentesBySistemaAsync(codSistema);

        public async Task<IEnumerable<ComponenteResponse>> BuscarComponentesAsync(string criterio)
            => await _repository.BuscarComponentesAsync(criterio);
    }
}

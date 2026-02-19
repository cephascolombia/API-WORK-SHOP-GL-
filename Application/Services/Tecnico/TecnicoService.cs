using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Marca;
using WorkShopGL.Infrastructure.Repositories.Tecnicos;

namespace WorkShopGL.Application.Services.Tecnico
{
    public class TecnicoService : ITecnicoService
    {
        private readonly ITecnicoRepository _tecnicoRepository;


        public TecnicoService(ITecnicoRepository tecnicoRepository)
            => _tecnicoRepository = tecnicoRepository;

        public async Task<string> Insert(CreateTecnicoDTO dto)
                    => await _tecnicoRepository.Insert(dto);

        public async Task<string> Update(EditTecnicoDTO dto)
                    => await _tecnicoRepository.Update(dto);

        public async Task<string> Delete(string codigo)
                    => await _tecnicoRepository.Delete(codigo);

        public async Task<PagedResult<TecnicoBusquedaDTO>> GetAll(QueryTecnicoDTO query)
        {
            var data = await _tecnicoRepository.GetAll(query);

            var result = new PagedResult<TecnicoBusquedaDTO>
            {
                Items = data,
                PaginaActual = query.Pagina,
                RegistrosXPagina = query.RegistrosXPag,
                TotalRegistros = 0,
                TotalPaginas = 0
            };

            if (data != null && data.Count > 0)
            {
                result.TotalRegistros = data[0].TotalRegistros;
                result.TotalPaginas = data[0].TotalPaginas;
            }

            return result;
        }
    }
}

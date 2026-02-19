using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Tecnico
{
    public interface ITecnicoService
    {
        Task<string> Insert(CreateTecnicoDTO dto);
        Task<string> Update(EditTecnicoDTO dto);
        Task<string> Delete(string codigo);
        Task<PagedResult<TecnicoBusquedaDTO>> GetAll(QueryTecnicoDTO query);
    }
}

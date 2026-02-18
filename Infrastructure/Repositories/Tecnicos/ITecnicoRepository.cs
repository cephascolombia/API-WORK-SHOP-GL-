using WorkShopGL.Application.DTO;

namespace WorkShopGL.Infrastructure.Repositories.Tecnicos
{
    public interface ITecnicoRepository
    {
        Task<string> Insert(CreateTecnicoDTO dto);
        Task<string> Update(EditTecnicoDTO dto);
        Task<string> Delete(string codigo);
        Task<List<TecnicoBusquedaDTO>> GetAll(QueryTecnicoDTO query);
    }
}

using WorkShopGL.Application.DTO;

namespace WorkShopGL.Infrastructure.Repositories.Marca
{
    public interface IMarcaRespository 
    {
        Task<string> Insert(CreateMarcaDTO dto);
        Task<string> Update(EditMarcaDTO dto);
        Task<string> Delete(string codigo);
    }
}

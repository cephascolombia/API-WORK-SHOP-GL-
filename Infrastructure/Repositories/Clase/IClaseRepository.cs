using WorkShopGL.Application.DTO;

namespace WorkShopGL.Infrastructure.Repositories.Clase
{
    public interface IClaseRepository
    {
        Task<string> Insert(CreateClaseDTO dto);
        Task<string> Update(EditClaseDTO dto);
        Task<string> Delete(string codigo);
    }
}

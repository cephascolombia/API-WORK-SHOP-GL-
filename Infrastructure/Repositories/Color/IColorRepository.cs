using WorkShopGL.Application.DTO;

namespace WorkShopGL.Infrastructure.Repositories.Color
{
    public interface IColorRepository
    {
        Task<string> Insert(CreateColorDTO dto);
        Task<string> Update(EditColorDTO dto);
        Task<string> Delete(string codigo);
    }
}

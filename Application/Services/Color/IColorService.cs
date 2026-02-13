using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Color
{
    public interface IColorService
    {
        Task<string> Insert(CreateColorDTO dto);
        Task<string> Update(EditColorDTO dto);
        Task<string> Delete(string codigo);
    }
}

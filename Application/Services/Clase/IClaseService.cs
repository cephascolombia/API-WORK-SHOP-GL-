using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Clase
{
    public interface IClaseService
    {
        Task<string> Insert(CreateClaseDTO dto);
        Task<string> Update(EditClaseDTO dto);
        Task<string> Delete(string codigo);
    }
}

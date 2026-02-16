using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Marca
{
    public interface IMarcaService
    {
        Task<string> Insert(CreateMarcaDTO dto);
        Task<string> Update(EditMarcaDTO dto);
        Task<string> Delete(string codigo);
    }
}

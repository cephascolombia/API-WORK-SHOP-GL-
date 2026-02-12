using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Cliente
{
    public interface IClienteService
    {
        Task<IEnumerable<QueryClienteDTO>?> GetAll();
        Task<QueryClienteDTO?> GetByCodigo(string codigo);
        Task<QueryClienteDTO?> GetByNit(string nit);
        Task<string> Insert(CreateClienteDTO dto);
        Task<string> Update(EditClienteDTO dto);
        Task<string> Delete(List<string> codigos);
    }
}

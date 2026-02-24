using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Cliente
{
    public interface IClienteService
    {
        Task<IEnumerable<QueryClienteDTO>?> GetAll();
        Task<IEnumerable<QueryClienteDTO>?> GetPaged(string? nit, string? nombre, string? codigo, int pageNumber, int pageSize);
        Task<QueryClienteDTO?> GetByCodigo(string codigo);
        Task<QueryClienteDTO?> GetByNit(string nit);
        Task<string> Insert(CreateClienteDTO dto);
        Task<string> Update(EditClienteDTO dto);
        Task<string> Delete(List<string> codigos);
    }
}

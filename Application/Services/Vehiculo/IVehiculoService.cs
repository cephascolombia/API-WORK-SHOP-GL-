using WorkShopGL.Application.DTO;

namespace WorkShopGL.Application.Services.Vehiculo
{
    public interface IVehiculoService    {
        Task<IEnumerable<QueryVehiculoDTO>?> GetAll();
        Task<IEnumerable<QueryVehiculoDTO>?> GetPaged(string? placa, string? cliente, int pageNumber, int pageSize);
        Task<QueryVehiculoDTO?> GetByPlaca(string placa);
        Task<QueryVehiculoDTO?> GetByCodigo(string codigo);
        Task<IEnumerable<QueryVehiculoDTO>?> GetByCliente(string codigo_cliente);
        Task<string> Insert(CreateVehiculoDTO dto);
        Task<string> Update(EditVehiculoDTO dto);
        Task<string> Delete(List<string> placas);
    }
}

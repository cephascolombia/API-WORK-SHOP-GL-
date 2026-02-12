using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Vehiculo;

namespace WorkShopGL.Application.Services.Vehiculo
{
    public class VehiculoService : IVehiculoService
    {
        private IVehiculoRepository _vehiculoRepository;
        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<string> Delete(List<string> placas)
        {
            return await _vehiculoRepository.Delete(placas);
        }

        public async Task<IEnumerable<QueryVehiculoDTO>?> GetAll()
        {
            return await _vehiculoRepository.GetAll();
        }

        public async Task<QueryVehiculoDTO?> GetByPlaca(string placa)
        {
            return await _vehiculoRepository.GetByPlaca(placa);
        }

        public async Task<QueryVehiculoDTO?> GetByCodigo(string codigo)
        {
            return await _vehiculoRepository.GetByCodigo(codigo);
        }
        public async Task<IEnumerable<QueryVehiculoDTO>?> GetByCliente(string codigo_cliente)
        {
            return await _vehiculoRepository.GetByCliente(codigo_cliente);
        }

        public async Task<string> Insert(CreateVehiculoDTO dto)
        {
            return await _vehiculoRepository.Insert(dto);
        }

        public async Task<string> Update(EditVehiculoDTO dto)
        {
            return await _vehiculoRepository.Update(dto);
        }
    }
}

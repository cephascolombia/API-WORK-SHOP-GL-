using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Cliente;

namespace WorkShopGL.Application.Services.Cliente
{
    public class ClienteService:IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<QueryClienteDTO>?> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<QueryClienteDTO?> GetByCodigo(string codigo)
        {
            return await _clienteRepository.GetByCodigo(codigo);
        }

        public Task<QueryClienteDTO?> GetByNit(string nit)
        {
            return _clienteRepository.GetByNit(nit);
        }

        public Task<string> Insert(CreateClienteDTO dto)
        {
            return _clienteRepository.Insert(dto);
        }

        public Task<string> Update(EditClienteDTO dto)
        {
            return _clienteRepository.Update(dto);
        }

        public async Task<string> Delete(List<string> codigos)
        {
            return await _clienteRepository.Delete(codigos);
        }
    }
}

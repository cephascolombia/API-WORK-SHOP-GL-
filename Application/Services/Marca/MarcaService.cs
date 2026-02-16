using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Marca;

namespace WorkShopGL.Application.Services.Marca
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRespository _marcaRepository;


        public MarcaService(IMarcaRespository claseRepository)
            => _marcaRepository = claseRepository;

        public async Task<string> Insert(CreateMarcaDTO dto)
                    => await _marcaRepository.Insert(dto);

        public async Task<string> Update(EditMarcaDTO dto)
            => await _marcaRepository.Update(dto);

        public async Task<string> Delete(string codigo)
            => await _marcaRepository.Delete(codigo);
    }
}

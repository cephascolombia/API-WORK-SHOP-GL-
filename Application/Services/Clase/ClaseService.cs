using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Clase;

namespace WorkShopGL.Application.Services.Clase
{
    public class ClaseService : IClaseService
    {
        private readonly IClaseRepository _claseRepository;

        public ClaseService(IClaseRepository claseRepository)
            => _claseRepository = claseRepository;

        public async Task<string> Insert(CreateClaseDTO dto)
                    => await _claseRepository.Insert(dto);

        public async Task<string> Update(EditClaseDTO dto)
            => await _claseRepository.Update(dto);

        public async Task<string> Delete(string codigo)
            => await _claseRepository.Delete(codigo);
    }
}

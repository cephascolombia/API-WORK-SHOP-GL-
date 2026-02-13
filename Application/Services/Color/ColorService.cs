using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Color;

namespace WorkShopGL.Application.Services.Color
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
            => _colorRepository = colorRepository;

        public async Task<string> Delete(string codigo)
                    => await _colorRepository.Delete(codigo);

        public async Task<string> Insert(CreateColorDTO dto)
                    => await _colorRepository.Insert(dto);

        public async Task<string> Update(EditColorDTO dto)
                    => await _colorRepository.Update(dto);
    }
}

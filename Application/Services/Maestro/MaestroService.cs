using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Repositories.Maestro;

namespace WorkShopGL.Application.Services.Maestro
{
    public class MaestroService : IMaestroService
    {
        private readonly IMaestroRepository _maestroRepository;

        public MaestroService(IMaestroRepository maestroRepository)
        {
            _maestroRepository = maestroRepository;
        }

        public async Task<IEnumerable<QueryPaisDTO>?> GetPaises()
        {
            return await _maestroRepository.GetPaises();    
        }

        public async Task<IEnumerable<QueryCiudadDTO>?> GetCiudades()
        {
           return await _maestroRepository.GetCiudades();
        }

        public async Task<IEnumerable<QueryColorDTO>?> GetColores()
        {
            return await _maestroRepository.GetColores();
        }

        public async Task<IEnumerable<QueryClaseDTO>?> GetClases()
        {
            return await _maestroRepository.GetClases();
        }

        public async Task<IEnumerable<QueryCarroceriaDTO>?> GetCarrocerias()
        {
            return await _maestroRepository.GetCarrocerias();
        }

        public async Task<IEnumerable<QueryMarcaDTO>?> GetMarcas()
        {
            return await _maestroRepository.GetMarcas();
        }
    }
}

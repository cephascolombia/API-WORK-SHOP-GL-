using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.Infrastructure.Repositories.Maestro
{
    public class MaestroRepository: IMaestroRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public MaestroRepository(SqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public async Task<IEnumerable<QueryPaisDTO>?> GetPaises()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PAISES",
               rd => rd.MapTo<QueryPaisDTO>());
        }

        public async Task<IEnumerable<QueryCiudadDTO>?> GetCiudades()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_CIUDADES",
               rd => rd.MapTo<QueryCiudadDTO>());
        }

        public async Task<IEnumerable<QueryColorDTO>?> GetColores()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_COLORES",
               rd => rd.MapTo<QueryColorDTO>());
        }

        public async Task<IEnumerable<QueryClaseDTO>?> GetClases()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_CLASES",
               rd => rd.MapTo<QueryClaseDTO>());
        }

        public async Task<IEnumerable<QueryCarroceriaDTO>?> GetCarrocerias()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_CARROCERIAS",
               rd => rd.MapTo<QueryCarroceriaDTO>());
        }

        public async Task<IEnumerable<QueryMarcaDTO>?> GetMarcas()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_MARCAS",
               rd => rd.MapTo<QueryMarcaDTO>());
        }
    }
}

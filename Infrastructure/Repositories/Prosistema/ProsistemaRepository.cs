using WorkShopGL.API.Models.Responses;
using WorkShopGL.Infrastructure.Database;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.Infrastructure.Repositories.Prosistema
{
    public class ProsistemaRepository : IProsistemaRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        // Inyectamos SqlExecutor, no DapperContext
        public ProsistemaRepository(SqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public async Task<IEnumerable<SistemaSimpleResponse>> GetSistemasAsync()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PROSISTEMA",
                rd => rd.MapTo<SistemaSimpleResponse>(),
                p => p.AddWithValue("@OPERACION", "S"));
        }

        public async Task<IEnumerable<ProsistemaResponse>> GetComponentesBySistemaAsync(string codSistema)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PROSISTEMA",
                rd => rd.MapTo<ProsistemaResponse>(),
                p =>
                {
                    p.AddWithValue("@OPERACION", "SC");
                    p.AddWithValue("@COD_SISTEMA", codSistema);
                });
        }

        public async Task<IEnumerable<ProsistemaResponse>> BuscarComponentesAsync(string criterio)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PROSISTEMA",
                rd => rd.MapTo<ProsistemaResponse>(),
                p =>
                {
                    p.AddWithValue("@OPERACION", "B");
                    p.AddWithValue("@BUSQUEDA", criterio);
                });
        }
    }
}
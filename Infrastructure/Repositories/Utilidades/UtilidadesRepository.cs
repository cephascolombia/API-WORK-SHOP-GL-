using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.Infrastructure.Repositories.Utilidades
{
    public class UtilidadesRepository : IUtilidadesRepository
    {
        private readonly SqlExecutorNoTenant _sqlExecutor;

        public UtilidadesRepository(SqlExecutorNoTenant sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public async Task<IEnumerable<QueryEmpresaDTO>?> GetAll()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_EMPRESAS",
            rd => rd.MapTo<QueryEmpresaDTO>(),
            p => p.AddWithValue("@OPERACION", "GETALL"));
        }

        public async Task<QueryEmpresaDTO?> GetByNit(string nit)
        {
            return await _sqlExecutor.ExecuteReaderAsync("SP_API_EMPRESAS",
            rd => rd.MapTo<QueryEmpresaDTO>(),
            p =>
            {
                p.AddWithValue("@OPERACION", "GETONE");
                p.AddWithValue("@NIT", nit);
            });
        }
    }
}

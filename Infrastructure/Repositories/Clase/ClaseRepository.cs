using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;

namespace WorkShopGL.Infrastructure.Repositories.Clase
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public ClaseRepository(SqlExecutor sqlExecutor)
            => _sqlExecutor = sqlExecutor;

        public async Task<string> Delete(string codigo)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_ADD_UPD_CLASES", p =>
            {
                p.AddWithValue("@OPERACION", "DEL");
                p.AddWithValue("@CODIGO", codigo);
            });
        }

        public async Task<string> Insert(CreateClaseDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_ADD_UPD_CLASES", p =>
            {
                p.AddWithValue("@OPERACION", "ADD");
                p.AddWithValue("@NOMBRE", dto.Nombre);
            });
        }

        public async Task<string> Update(EditClaseDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_ADD_UPD_CLASES", p =>
            {
                p.AddWithValue("@OPERACION", "UPD");
                p.AddWithValue("@CODIGO", dto.Codigo);
                p.AddWithValue("@NOMBRE", dto.Nombre);
            });
        }
    }
}

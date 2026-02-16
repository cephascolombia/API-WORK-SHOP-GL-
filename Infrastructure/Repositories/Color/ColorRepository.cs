using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;

namespace WorkShopGL.Infrastructure.Repositories.Color
{
    public class ColorRepository : IColorRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public ColorRepository(SqlExecutor sqlExecutor)
            => _sqlExecutor = sqlExecutor;

        public async Task<string> Delete(string codigo)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_ADD_UPD_COLORES", 
                p =>
            {
                p.AddWithValue("@OPERACION", "DEL");
                p.AddWithValue("@CODIGO", codigo);
            });
        }

        public async Task<string> Insert(CreateColorDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_ADD_UPD_COLORES", 
                p =>
            {
                p.AddWithValue("@OPERACION", "ADD");
                p.AddWithValue("@NOMBRE", dto.Nombre);
            });
        }

        public async Task<string> Update(EditColorDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_ADD_UPD_COLORES", p =>
            {
                p.AddWithValue("@OPERACION", "UPD");
                p.AddWithValue("@CODIGO", dto.Codigo);
                p.AddWithValue("@NOMBRE", dto.Nombre);
            });
        }
    }
}

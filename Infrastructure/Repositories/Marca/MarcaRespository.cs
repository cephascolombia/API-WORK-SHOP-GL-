using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;

namespace WorkShopGL.Infrastructure.Repositories.Marca
{
    public class MarcaRespository : IMarcaRespository
    {
        private readonly SqlExecutor _sqlExecutor;

        public MarcaRespository(SqlExecutor sqlExecutor)
            => _sqlExecutor = sqlExecutor;

        public async Task<string> Delete(string codigo)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_CUD_MARCAS", p =>
            {
                p.AddWithValue("@OPERACION", "DEL");
                p.AddWithValue("@CODIGO", codigo);
            });
        }

        public async Task<string> Insert(CreateMarcaDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_CUD_MARCAS", p =>
            {
                p.AddWithValue("@OPERACION", "ADD");
                p.AddWithValue("@NOMBRE", dto.nomMarV);
            });
        }

        public async Task<string> Update(EditMarcaDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_CUD_MARCAS", p =>
            {
                p.AddWithValue("@OPERACION", "UPD");
                p.AddWithValue("@CODIGO", dto.codMarV);
                p.AddWithValue("@NOMBRE", dto.nomMarV);
            });
        }
    }
}

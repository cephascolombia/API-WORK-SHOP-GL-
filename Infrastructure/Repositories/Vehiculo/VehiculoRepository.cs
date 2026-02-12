using System.Xml.Linq;
using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.Infrastructure.Repositories.Vehiculo
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public VehiculoRepository(SqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public async Task<IEnumerable<QueryVehiculoDTO>?> GetAll()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_VEHICULOS",
              rd => rd.MapTo<QueryVehiculoDTO>(),
              p => p.AddWithValue("@OPERACION", "GETALL"));
        }

        public async Task<QueryVehiculoDTO?> GetByPlaca(string placa)
        {
            return await _sqlExecutor.ExecuteReaderAsync("SP_API_VEHICULOS",
              rd => rd.MapTo<QueryVehiculoDTO>(),
              p =>
              {
                  p.AddWithValue("@OPERACION", "GETPLACA");
                  p.AddWithValue("@PLACA", placa);
              });
        }

        public async Task<QueryVehiculoDTO?> GetByCodigo(string codigo)
        {
            return await _sqlExecutor.ExecuteReaderAsync("SP_API_VEHICULOS",
              rd => rd.MapTo<QueryVehiculoDTO>(),
              p =>
              {
                  p.AddWithValue("@OPERACION", "GETONE");
                  p.AddWithValue("@CODIGO", codigo);
              });
        }

        public async Task<IEnumerable<QueryVehiculoDTO>?> GetByCliente(string codigo_cliente)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_VEHICULOS",
              rd => rd.MapTo<QueryVehiculoDTO>(),
              p =>
              {
                  p.AddWithValue("@OPERACION", "GET_BY_CLIENTE");
                  p.AddWithValue("@CLIENTE", codigo_cliente);
              });
        }

        public async Task<string> Insert(CreateVehiculoDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate(
                 "SP_API_CUD_VEHICULO",
                 p =>
                 {
                     p.AddWithValue("@OPERACION", "I");
                     p.AddWithValue("@PLACA", dto.Placa);
                     p.AddWithValue("@CLIENTE", dto.Codigo_cliente);
                     p.AddWithValue("@MODELO", dto.Modelo);
                     p.AddWithValue("@MARCA", dto.Codigo_marca);
                     p.AddWithValue("@COLOR", dto.Codigo_color);
                     p.AddWithValue("@CARROCERIA", dto.Codigo_carroceria);
                     p.AddWithValue("@CLASE", dto.Codigo_clase);
                     p.AddWithValue("@CILINDRAJE", dto.Cilindraje);
                 }
             );
        }

        public async Task<string> Update(EditVehiculoDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate(
                 "SP_API_CUD_VEHICULO",
                 p =>
                 {
                     p.AddWithValue("@OPERACION", "U");
                     p.AddWithValue("@PLACA", dto.Placa);
                     p.AddWithValue("@CODIGO", dto.Codigo);
                     p.AddWithValue("@CLIENTE", dto.Codigo_cliente);
                     p.AddWithValue("@MODELO", dto.Modelo);
                     p.AddWithValue("@MARCA", dto.Codigo_marca);
                     p.AddWithValue("@COLOR", dto.Codigo_color);
                     p.AddWithValue("@CARROCERIA", dto.Codigo_carroceria);
                     p.AddWithValue("@CLASE", dto.Codigo_clase);
                     p.AddWithValue("@CILINDRAJE", dto.Cilindraje);
                 }
             );
        }

        public async Task<string> Delete(List<string> codigos)
        {
            var xml = new XElement("Vehiculos",
                codigos.Select(c => new XElement("Codigo", c))
              ).ToString();

            return await _sqlExecutor.ExecutedInsertOrUpdate(
                "SP_API_CUD_VEHICULO",
                p =>
                {
                    p.AddWithValue("@OPERACION", "D");
                    p.AddWithValue("@XML_CODIGOS", xml);
                }
            );
        }
    }
}

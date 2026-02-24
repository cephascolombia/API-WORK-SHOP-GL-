using System.Xml.Linq;
using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.Infrastructure.Repositories.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public ClienteRepository(SqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public async Task<IEnumerable<QueryClienteDTO>?> GetAll()
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_CLIENTES",
               rd => rd.MapTo<QueryClienteDTO>());
        }

        public async Task<IEnumerable<QueryClienteDTO>?> GetPaged(string? nit, string? nombre, string? codigo, int pageNumber, int pageSize)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PAGE_CLIENTES",
               rd => rd.MapTo<QueryClienteDTO>(),
               p =>
               {
                   p.AddWithValue("@NIT", (object?)nit ?? DBNull.Value);
                   p.AddWithValue("@NOMBRE", (object?)nombre ?? DBNull.Value);
                   p.AddWithValue("@CODIGO", (object?)codigo ?? DBNull.Value);
                   p.AddWithValue("@PageNumber", pageNumber);
                   p.AddWithValue("@RowsOfPage", pageSize);
               });
        }

        public async Task<QueryClienteDTO?> GetByCodigo(string codigo)
        {
            return await _sqlExecutor.ExecuteReaderAsync("SP_API_GET_CLIENTES",
               rd => rd.MapTo<QueryClienteDTO>(),
               p => p.AddWithValue("@CODIGO", codigo));
        }

        public async Task<QueryClienteDTO?> GetByNit(string nit)
        {
            return await _sqlExecutor.ExecuteReaderAsync("SP_API_GET_CLIENTES",
               rd => rd.MapTo<QueryClienteDTO>(),
               p => p.AddWithValue("@NIT", nit));
        }

        public async Task<string> Insert(CreateClienteDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate(
                 "SP_API_ADD_CLIENTES",
                 p =>
                 {
                     p.AddWithValue("@NIT", dto.Nit);
                     p.AddWithValue("@TIPO_DOCUMENTO", dto.TipoDocumento);
                     p.AddWithValue("@TIPO_PERSONA", dto.TipoPersona);
                     p.AddWithValue("@PRIMER_NOMBRE", dto.PrimerNombre);
                     p.AddWithValue("@SEGUNDO_NOMBRE", dto.SegundoNombre ?? string.Empty);
                     p.AddWithValue("@PRIMER_APELLIDO", dto.PrimerApellido);
                     p.AddWithValue("@SEGUNDO_APELLIDO", dto.SegundoApellido ?? string.Empty);
                     p.AddWithValue("@DIRECCION", dto.Direccion);
                     p.AddWithValue("@TELEFONO", dto.Telefono);
                     p.AddWithValue("@EMAIL", dto.Email);
                     p.AddWithValue("@CELULAR", dto.Celular);
                     p.AddWithValue("@CIUDAD", dto.CodigoCiudad);
                     p.AddWithValue("@PAIS", dto.CodigoPais);
                 }
             );
        }

        public async Task<string> Update(EditClienteDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate(
                  "SP_API_UPD_CLIENTES",
                  p =>
                  {
                      p.AddWithValue("@CODIGO", dto.Codigo);
                      p.AddWithValue("@NIT", dto.Nit);
                      p.AddWithValue("@TIPO_DOCUMENTO", dto.TipoDocumento);
                      p.AddWithValue("@TIPO_PERSONA", dto.TipoPersona);
                      p.AddWithValue("@PRIMER_NOMBRE", dto.PrimerNombre);
                      p.AddWithValue("@SEGUNDO_NOMBRE", dto.SegundoNombre ?? string.Empty);
                      p.AddWithValue("@PRIMER_APELLIDO", dto.PrimerApellido);
                      p.AddWithValue("@SEGUNDO_APELLIDO", dto.SegundoApellido ?? string.Empty);
                      p.AddWithValue("@DIRECCION", dto.Direccion);
                      p.AddWithValue("@TELEFONO", dto.Telefono);
                      p.AddWithValue("@EMAIL", dto.Email);
                      p.AddWithValue("@CELULAR", dto.Celular);
                      p.AddWithValue("@CIUDAD", dto.CodigoCiudad);
                      p.AddWithValue("@PAIS", dto.CodigoPais);
                  }
              );
        }

        public async Task<string> Delete(List<string> codigos)
        {
            var xml = new XElement("Clientes",
                codigos.Select(c => new XElement("Codigo", c))
              ).ToString();

            return await _sqlExecutor.ExecutedInsertOrUpdate(
                "SP_API_DEL_CLIENTES",
                p =>
                {
                    p.AddWithValue("@XML_CODIGOS", xml);
                }
            );
        }
    }
}

using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;

namespace WorkShopGL.Infrastructure.Repositories.Tecnicos
{
    public class TecnicoRepository : ITecnicoRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public TecnicoRepository(SqlExecutor sqlExecutor)
            => _sqlExecutor = sqlExecutor;

        public async Task<string> Insert(CreateTecnicoDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_CRUD_TECNICOS", p =>
            {
                p.AddWithValue("@OPERACION", "I");
                p.AddWithValue("@NIT", dto.nit);
                p.AddWithValue("@TIPO_DOCUMENTO", dto.tipoDocumento);
                p.AddWithValue("@TIPO_PERSONA", dto.tipoPersona);
                p.AddWithValue("@PRIMER_NOMBRE", dto.primerNombre);
                p.AddWithValue("@SEGUNDO_NOMBRE", dto.segundoNombre);
                p.AddWithValue("@PRIMER_APELLIDO", dto.primerApellido);
                p.AddWithValue("@SEGUNDO_APELLIDO", dto.segundoApellido);
                p.AddWithValue("@DIRECCION", dto.direccion);
                p.AddWithValue("@TELEFONO", dto.telefono);
                p.AddWithValue("@EMAIL", dto.email);
                p.AddWithValue("@CELULAR", dto.celular);
                p.AddWithValue("@CIUDAD", dto.codigoCiudad);
                p.AddWithValue("@NOMBRE_CIUDAD", dto.nombreCiudad);
                p.AddWithValue("@PAIS", dto.codigoPais);
                p.AddWithValue("@NOMBRE_PAIS", dto.nombrePais);

            });
        }

        public async Task<string> Update(EditTecnicoDTO dto)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_CRUD_TECNICOS", p =>
            {
                p.AddWithValue("@OPERACION", "U");
                p.AddWithValue("@CODIGO_TECNICO", dto.CodigoTecnico);
                p.AddWithValue("@NIT", dto.nit);
                p.AddWithValue("@TIPO_DOCUMENTO", dto.tipoDocumento);
                p.AddWithValue("@TIPO_PERSONA", dto.tipoPersona);
                p.AddWithValue("@PRIMER_NOMBRE", dto.primerNombre);
                p.AddWithValue("@SEGUNDO_NOMBRE", dto.segundoNombre);
                p.AddWithValue("@PRIMER_APELLIDO", dto.primerApellido);
                p.AddWithValue("@SEGUNDO_APELLIDO", dto.segundoApellido);
                p.AddWithValue("@DIRECCION", dto.direccion);
                p.AddWithValue("@TELEFONO", dto.telefono);
                p.AddWithValue("@EMAIL", dto.email);
                p.AddWithValue("@CELULAR", dto.celular);
                p.AddWithValue("@CIUDAD", dto.codigoCiudad);
                p.AddWithValue("@NOMBRE_CIUDAD", dto.nombreCiudad);
                p.AddWithValue("@PAIS", dto.codigoPais);
                p.AddWithValue("@NOMBRE_PAIS", dto.nombrePais);
            });
        }

        public async Task<string> Delete(string codigo)
        {
            return await _sqlExecutor.ExecutedInsertOrUpdate("SP_API_CRUD_TECNICOS", p =>
            {
                p.AddWithValue("@OPERACION", "D");
                p.AddWithValue("@CODIGO_TECNICO", codigo);
            });
        }

        public async Task<List<TecnicoBusquedaDTO>> GetAll(QueryTecnicoDTO query)
        {
            return await _sqlExecutor.ExecuteReaderListAsync<TecnicoBusquedaDTO>("SP_API_CRUD_TECNICOS", rd =>
            {
                return new TecnicoBusquedaDTO
                {
                    Cedula = rd["Cedula"].ToString() ?? string.Empty,
                    Codigo = rd["Codigo"].ToString() ?? string.Empty,
                    Nombre = rd["Nombre"].ToString() ?? string.Empty,
                    Direccion = rd["Direccion"].ToString() ?? string.Empty,
                    Celular = rd["Celular"].ToString() ?? string.Empty,
                    Email = rd["Email"].ToString() ?? string.Empty,
                    Ciudad = rd["Ciudad"].ToString() ?? string.Empty,
                    Pais = rd["Pais"].ToString() ?? string.Empty,
                    TotalRegistros = Convert.ToInt32(rd["TotalRegistros"]),
                    TotalPaginas = Convert.ToInt32(rd["TotalPaginas"])
                };
            }, p =>
            {
                p.AddWithValue("@OPERACION", "S");
                p.AddWithValue("@BUSQUEDA", query.Busqueda ?? "");
                p.AddWithValue("@PAGINA", query.Pagina);
                p.AddWithValue("@REGISTROS_X_PAG", query.RegistrosXPag);
            });
        }
    }
}

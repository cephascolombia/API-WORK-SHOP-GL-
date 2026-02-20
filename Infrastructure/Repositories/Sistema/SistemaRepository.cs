using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Database;

namespace WorkShopGL.Infrastructure.Repositories.Sistema
{
    public class SistemaRepository : ISistemaRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public SistemaRepository(SqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public async Task<PagedResult<SistemaSimpleResponse>> GetSistemasAsync(QuerySistemaDTO query)
        {
            var items = await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PROSISTEMA", rd =>
            {
                return new SistemaSimpleResponse
                {
                    ID = Convert.ToInt32(rd["ID"]),
                    Codigo = rd["Codigo"] != DBNull.Value ? rd["Codigo"].ToString() : string.Empty,
                    Nombre = rd["Nombre"] != DBNull.Value ? rd["Nombre"].ToString() : string.Empty,
                    CodSistema = rd["CodSistema"] != DBNull.Value ? rd["CodSistema"].ToString() : string.Empty,
                    TotalRegistros = Convert.ToInt32(rd["TotalRegistros"]),
                    TotalPaginas = Convert.ToInt32(rd["TotalPaginas"])
                };
            }, p =>
            {
                p.AddWithValue("@OPERACION", "S");
                p.AddWithValue("@BUSQUEDA", string.IsNullOrEmpty(query.Busqueda) ? DBNull.Value : query.Busqueda);
                p.AddWithValue("@PAGINA", query.Pagina);
                p.AddWithValue("@REGISTROS_X_PAG", query.RegistrosXPagina);
            });

            var result = new PagedResult<SistemaSimpleResponse>
            {
                Items = items,
                TotalRegistros = items.FirstOrDefault()?.TotalRegistros ?? 0,
                TotalPaginas = items.FirstOrDefault()?.TotalPaginas ?? 0,
                PaginaActual = query.Pagina,
                RegistrosXPagina = query.RegistrosXPagina
            };

            return result;
        }

        public async Task<IEnumerable<ComponenteResponse>> GetComponentesBySistemaAsync(string codSistema)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PROSISTEMA", rd =>
            {
                return new ComponenteResponse
                {
                    Delmrk = rd["Delmrk"] != DBNull.Value ? rd["Delmrk"].ToString() : string.Empty,
                    ID = Convert.ToInt32(rd["ID"]),
                    Codigo = rd["Codigo"] != DBNull.Value ? rd["Codigo"].ToString() : string.Empty,
                    CodSistema = rd["CodSistema"] != DBNull.Value ? rd["CodSistema"].ToString() : string.Empty,
                    nomSistema = rd["nomSistema"] != DBNull.Value ? rd["nomSistema"].ToString() : string.Empty,
                    nomSubSistema = rd["nomSubSistema"] != DBNull.Value ? rd["nomSubSistema"].ToString() : string.Empty,
                    Nombre = rd["Nombre"] != DBNull.Value ? rd["Nombre"].ToString() : string.Empty,
                    CodSubSistema = rd["CodSubSistema"] != DBNull.Value ? rd["CodSubSistema"].ToString() : string.Empty
                };
            }, p =>
            {
                p.AddWithValue("@OPERACION", "SC");
                p.AddWithValue("@COD_SISTEMA", codSistema);
            });
        }

        public async Task<IEnumerable<ComponenteResponse>> BuscarComponentesAsync(string criterio)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("SP_API_GET_PROSISTEMA", rd =>
            {
                return new ComponenteResponse
                {
                    Delmrk = rd["Delmrk"] != DBNull.Value ? rd["Delmrk"].ToString() : string.Empty,
                    ID = Convert.ToInt32(rd["ID"]),
                    Codigo = rd["Codigo"] != DBNull.Value ? rd["Codigo"].ToString() : string.Empty,
                    CodSistema = rd["CodSistema"] != DBNull.Value ? rd["CodSistema"].ToString() : string.Empty,
                    nomSistema = rd["nomSistema"] != DBNull.Value ? rd["nomSistema"].ToString() : string.Empty,
                    nomSubSistema = rd["nomSubSistema"] != DBNull.Value ? rd["nomSubSistema"].ToString() : string.Empty,
                    Nombre = rd["Nombre"] != DBNull.Value ? rd["Nombre"].ToString() : string.Empty,
                    CodSubSistema = rd["CodSubSistema"] != DBNull.Value ? rd["CodSubSistema"].ToString() : string.Empty
                };
            }, p =>
            {
                p.AddWithValue("@OPERACION", "B");
                p.AddWithValue("@BUSQUEDA", criterio);
            });
        }
    }
}

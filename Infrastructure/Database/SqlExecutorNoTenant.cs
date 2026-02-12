using Microsoft.Data.SqlClient;
using System.Data;

namespace WorkShopGL.Infrastructure.Database
{
    public class SqlExecutorNoTenant
    {
        private readonly SqlConnectionNoTenantFactory _factory;
        public SqlExecutorNoTenant(SqlConnectionNoTenantFactory factory)
        {
            _factory = factory;
        }
        /// <summary>
        /// Ejecuta un Stored Procedure que retorna un único valor (scalar).
        /// Útil para INSERT que devuelven un ID o consultas simples.
        /// </summary>
        /// <typeparam name="T">Tipo del valor esperado.</typeparam>
        /// <param name="storedProcedure">Nombre del Stored Procedure.</param>
        /// <param name="parameters">Acción para agregar parámetros SQL.</param>
        /// <returns>Valor escalar convertido al tipo T o default.</returns>
        public async Task<T?> ExecuteScalarAsync<T>(string storedProcedure, Action<SqlParameterCollection>? parameters = null)
        {
            using var cn = _factory.Create();
            using var cmd = CreateCommand(cn, storedProcedure, parameters);

            cn.Open();
            var result = await cmd.ExecuteScalarAsync();
            return result == null ? default : (T)result;
        }

        /// <summary>
        /// Ejecuta un Stored Procedure que no retorna datos.
        /// Útil para UPDATE, DELETE o acciones administrativas.
        /// </summary>
        /// <param name="storedProcedure">Nombre del Stored Procedure.</param>
        /// <param name="parameters">Acción para agregar parámetros SQL.</param>
        public async Task ExecuteNonQueryAsync(string storedProcedure, Action<SqlParameterCollection>? parameters = null)
        {
            using var cn = _factory.Create();
            using var cmd = CreateCommand(cn, storedProcedure, parameters);

            cn.Open();
            await cmd.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// Ejecuta un Stored Procedure y mapea el primer registro retornado.
        /// Útil para obtener un único objeto.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a retornar.</typeparam>
        /// <param name="storedProcedure">Nombre del Stored Procedure.</param>
        /// <param name="map">Función que convierte un SqlDataReader en T.</param>
        /// <param name="parameters">Acción para agregar parámetros SQL.</param>
        /// <returns>Objeto mapeado o null si no hay registros.</returns>
        public async Task<T?> ExecuteReaderAsync<T>(string storedProcedure, Func<SqlDataReader, T> map, Action<SqlParameterCollection>? parameters = null)
        {
            using var cn = _factory.Create();
            using var cmd = CreateCommand(cn, storedProcedure, parameters);

            cn.Open();
            using var rd = await cmd.ExecuteReaderAsync();

            return rd.Read() ? map(rd) : default;
        }

        /// <summary>
        /// Ejecuta un Stored Procedure y mapea todos los registros retornados.
        /// Útil para listados.
        /// </summary>
        /// <typeparam name="T">Tipo de los objetos a retornar.</typeparam>
        /// <param name="storedProcedure">Nombre del Stored Procedure.</param>
        /// <param name="map">Función que convierte cada fila en T.</param>
        /// <param name="parameters">Acción para agregar parámetros SQL.</param>
        /// <returns>Lista de objetos mapeados.</returns>
        public async Task<List<T>> ExecuteReaderListAsync<T>(string storedProcedure, Func<SqlDataReader, T> map, Action<SqlParameterCollection>? parameters = null)
        {
            var list = new List<T>();

            using var cn = _factory.Create();
            using var cmd = CreateCommand(cn, storedProcedure, parameters);

            cn.Open();
            using var rd = await cmd.ExecuteReaderAsync();

            while (rd.Read())
            {
                list.Add(map(rd));
            }

            return list;
        }

        private static SqlCommand CreateCommand(SqlConnection cn, string sp, Action<SqlParameterCollection>? parameters)
        {
            var cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;

            parameters?.Invoke(cmd.Parameters);
            return cmd;
        }
    }
}

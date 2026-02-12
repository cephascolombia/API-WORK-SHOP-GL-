using Microsoft.Data.SqlClient;
using WorkShopGL.Shared.Context;
using WorkShopGL.Shared.Exeptions;

namespace WorkShopGL.Infrastructure.Database
{
    public class SqlConnectionFactory
    {
        private readonly TenantContext _tenant;

        public SqlConnectionFactory(TenantContext tenant)
        {
            _tenant = tenant;
        }

        public SqlConnection Create()
        {
            var cs = _tenant.ConnectionString;

            if (string.IsNullOrWhiteSpace(cs))
                throw new BusinessException("Cadena de conexión del tenant no válida");

            if (!cs.Contains("Server="))
                throw new BusinessException("La cadena de conexión del tenant no es una connection string válida");

            return new SqlConnection(cs);
        }
    }

}

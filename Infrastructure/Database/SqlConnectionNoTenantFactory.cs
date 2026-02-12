using Microsoft.Data.SqlClient;

namespace WorkShopGL.Infrastructure.Database
{
    public class SqlConnectionNoTenantFactory
    {
        private readonly IConfiguration _config;

        public SqlConnectionNoTenantFactory(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(
                _config.GetConnectionString("MasterDb")
            );
        }
    }
}

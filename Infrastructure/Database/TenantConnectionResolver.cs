using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.Infrastructure.Database
{
    public class TenantConnectionResolver : ITenantConnectionResolver
    {
        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly CryptoInt _crypto;

        public TenantConnectionResolver(IConfiguration config, IMemoryCache cache,CryptoInt cryptoInt)
        {
            _config = config;
            _cache = cache;
            _crypto = cryptoInt;
        }

        public async Task<string> ResolveAsync(string tenantKey)
        {
            if (string.IsNullOrWhiteSpace(tenantKey))
            {
                throw new ArgumentException("El tenantKey no puede ser nulo o vacío.", nameof(tenantKey));
            }

            var tenantTokenBytes = _crypto.Decrypt(tenantKey);

            var connectionString = await _cache.GetOrCreateAsync(
                $"TENANT_{tenantKey}",
                async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                    // Conexión a BD PRINCIPAL
                    using var cn = new SqlConnection(_config.GetConnectionString("MasterDb"));


                    using var cmd = new SqlCommand("SP_Tenants", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TENANTKEY", SqlDbType.Int).Value = tenantTokenBytes;
                    cmd.Parameters.AddWithValue("@OPERACION", "GET");

                    await cn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();

                    if (result is null)
                    {
                        throw new InvalidOperationException("No se pudo obtener la cadena de conexión cifrada para el tenant especificado.");
                    }

                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        throw new InvalidOperationException("No se pudo obtener la cadena de conexión cifrada para el tenant especificado.");
                    }

                    return result.ToString();
                });


            return _config.GetConnectionString(connectionString) ?? throw new InvalidOperationException("Se obtuvo un valor nulo inesperado al resolver la conexión del tenant."); ;
        }

        private string Decrypt(byte[] value)
        {
            var key = Encoding.UTF8.GetBytes(_config["Crypto:AesKey"]);

            var iv = Encoding.UTF8.GetBytes(_config["Crypto:AesIV"]);

            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(value);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }

    }
}

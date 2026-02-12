using System.Security.Cryptography;
using System.Text;

namespace WorkShopGL.Shared.Results
{
    public class CryptoInt
    {
        private readonly byte[] _key;

        public CryptoInt(IConfiguration config)
        {
            var secret = config["CryptoTenant:Key"];

            if (string.IsNullOrWhiteSpace(secret))
                throw new Exception("Crypto:Key no configurada");

            using var sha = SHA256.Create();
            _key = sha.ComputeHash(Encoding.UTF8.GetBytes(secret));
        }

        public string Encrypt(int value)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.GenerateIV();

            var plainBytes = Encoding.UTF8.GetBytes(value.ToString());

            using var encryptor = aes.CreateEncryptor();
            var cipher = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            var result = new byte[aes.IV.Length + cipher.Length];
            Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
            Buffer.BlockCopy(cipher, 0, result, aes.IV.Length, cipher.Length);

            return Convert.ToBase64String(result);
        }

        public int Decrypt(string encrypted)
        {
            var fullCipher = Convert.FromBase64String(encrypted);

            using var aes = Aes.Create();
            aes.Key = _key;

            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - 16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, 16);
            Buffer.BlockCopy(fullCipher, 16, cipher, 0, cipher.Length);

            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            var plainBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return int.Parse(Encoding.UTF8.GetString(plainBytes));
        }
    }
}

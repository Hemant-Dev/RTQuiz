using System.Security.Cryptography;

namespace Helpers
{
    public static class PasswordHasherHelper
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private const int _saltSize = 16;
        private const int _keySize = 20;
        private const int _iterations = 1000;



        // Generate Hash for Password

        public static string PasswordHasher(string userPassword)
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[_saltSize]);
            var key = new Rfc2898DeriveBytes(userPassword, salt, _iterations);
            var hash = key.GetBytes(_keySize);
            var hashByte = new byte[_keySize + _saltSize];
            Array.Copy(salt, 0, hashByte, 0, _saltSize);
            Array.Copy(hash, 0, hashByte, _saltSize, _keySize);
            var base64 = Convert.ToBase64String(hashByte);

            return base64;
        }

        // Verify Password Hash
        public static bool VerifyHashedPassword(string password, string base64Hash)
        {
            var hashBytes = Convert.FromBase64String(base64Hash);
            var salt = new byte[_saltSize];
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);
            var key = new Rfc2898DeriveBytes(password, salt, _iterations);
            byte[] hash = key.GetBytes(_keySize);

            for (var i = 0; i < _keySize; i++)
            {
                if (hashBytes[i + _saltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
        // Generate Refresh Token
    }
}

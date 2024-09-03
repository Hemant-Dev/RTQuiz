using System.Security.Cryptography;

namespace Helpers
{
    public static class PasswordHasherHelper
    {
        private const int _saltSize = 16;
        private const int _keySize = 32;
        private const int _iterations = 50000;

        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;


        // Generate Hash for Password

        public static string PasswordHasher(string userPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(userPassword, salt, _iterations, _algorithm, _keySize);

            var hashByte = new byte[hash.Length + _saltSize];
            Array.Copy(salt, 0, hashByte, 0, _saltSize);
            Array.Copy(hash, 0, hashByte, _saltSize, _keySize);
            var base64 = Convert.ToBase64String(hashByte);
            return base64;
        }

        // Verify Password Hash
        public static bool VerifyHashedPassword(string input, string hashString)
        {
            byte[] salt = new byte[_saltSize];
            var hashBytes = Convert.FromBase64String(hashString);
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(input, salt, _iterations, _algorithm, _keySize);
            for (var i = 0; i < _keySize; i++)
            {
                if (hashBytes[i + _saltSize] != hash[i])
                    return false;
            }
            return true;
        }
        // Generate Refresh Token
    }
}

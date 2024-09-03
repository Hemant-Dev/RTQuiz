using System.Security.Cryptography;

namespace Helpers
{
    public static class PasswordHasherHelper
    {
        private const int _saltSize = 16;  // Size of the salt
        private const int _hashSize = 32;  // Size of the hash
        private const int _iterations = 10000;  // Number of iterations
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;  // Hashing algorithm

        // Generate Hash for Password
        public static string PasswordHasher(string userPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);  // Generate a random salt
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(userPassword, salt, _iterations, _algorithm, _hashSize);  // Generate the hash

            byte[] hashBytes = new byte[_saltSize + _hashSize];  // Allocate byte array for salt + hash
            Array.Copy(salt, 0, hashBytes, 0, _saltSize);  // Copy salt to the beginning of hashBytes
            Array.Copy(hash, 0, hashBytes, _saltSize, _hashSize);  // Copy hash after the salt

            return Convert.ToBase64String(hashBytes);  // Convert to Base64 string and return
        }

        // Verify Password Hash
        public static bool VerifyHashedPassword(string password, string base64Hash)
        {
            var hashBytes = Convert.FromBase64String(base64Hash);  // Decode the Base64 hash
            var salt = new byte[_saltSize];
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);  // Extract the salt from the stored hash

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithm, _hashSize);  // Recompute the hash using the extracted salt

            // Compare the recomputed hash with the stored hash
            for (var i = 0; i < _hashSize; i++)
            {
                if (hashBytes[i + _saltSize] != hash[i])  // Compare byte by byte
                {
                    return false;  // Return false if any byte doesn't match
                }
            }

            return true;  // Return true if all bytes match
        }


        // Generate Refresh Token
    }
}

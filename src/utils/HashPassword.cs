using System;
using System.Security.Cryptography;

namespace Nhom8_QLTV.src.utils
{
    /// <summary>
    /// Đoạn code này được copy từ stackoverflow
    /// và tất nhiên là người copy cũng...chẳng hiểu gì 😐
    /// </summary>
    internal class HashPassword
    {
        /// <summary>
        /// Size of salt.
        /// </summary>
        private const int SALT_SIZE = 16;

        /// <summary>
        /// Size of hash.
        /// </summary>
        private const int HASH_SIZE = 32;

        /// <summary>
        /// Creates a hash from a password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="iterations"></param>
        /// <returns>The hash.</returns>
        public static string Hash(string password, int iterations)
        {
            // Create salt.
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SALT_SIZE]);

            // Create hash.
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HASH_SIZE);

            // Combine salt and hash.
            var hashBytes = new byte[SALT_SIZE + HASH_SIZE];
            Array.Copy(salt, 0, hashBytes, 0, SALT_SIZE);
            Array.Copy(hash, 0, hashBytes, SALT_SIZE, HASH_SIZE);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            // Format hash with extra information
            return String.Format("$IWDY${0}${1}", iterations, base64Hash);
        }

        /// <summary>
        /// Creates a hash from a password with 5000 iterations.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>The hash.</returns>
        public static string Hash(string password)
        {
            return Hash(password, 5000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashString"></param>
        /// <returns>Is Supported?</returns>
        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$IWDY$");
        }

        /// <summary>
        /// Verifies a password against a hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="hashedPassword">The hash.</param>
        /// <returns>Could be verified?</returns>
        /// <exception cref="NotSupportedException"></exception>
        public static bool Verify(string password, string hashedPassword)
        {
            // Check hash.
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported.");
            }

            // Extract iteration and base64 string.
            var splittedHashString = hashedPassword.Replace("$IWDY$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            // Get hash bytes.
            var hashBytes = Convert.FromBase64String(base64Hash);

            // Get salt.
            var salt = new byte[SALT_SIZE];
            Array.Copy(hashBytes, 0, salt, 0, SALT_SIZE);

            // Create hash with give salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

            // Get result
            for (var i = 0; i < HASH_SIZE; i++)
            {
                if (hashBytes[i + SALT_SIZE] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

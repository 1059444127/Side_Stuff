using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CoursePaperWpf
{
    public class PasswordHash
    {
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public static byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);
            return salt;
        }

        public static string CreateHash(string password, byte[] salt)
        {
            byte[] hash = Encrypt(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" + 
                Convert.ToBase64String(salt) + ":" + 
                Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string password, string hash)
        {
            string[] hashSplit = hash.Split(':');
            int iterations = int.Parse(hashSplit[0]);
            byte[] salt = Convert.FromBase64String(hashSplit[1]);
            byte[] fullHash = Convert.FromBase64String(hashSplit[2]);
            byte[] compareHash = Encrypt(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return fullHash.SequenceEqual(compareHash);
        }

        public static byte[] Encrypt(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}

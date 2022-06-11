using System;
using System.Security.Cryptography;
using System.Text;

namespace MusicTrackAPI.Services
{
	public static class PBKDF2HashGenerator
	{
        public const int SALT_SIZE = 24;
        public const int HASH_SIZE = 24; 
        public const int ITERATIONS = 100000; 

        public static string CreateHash(string input)
        {   
            byte[] salt = new byte[SALT_SIZE];

            RandomNumberGenerator.Create().GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS);
            return Encoding.UTF8.GetString(pbkdf2.GetBytes(HASH_SIZE));
        }
    }
}


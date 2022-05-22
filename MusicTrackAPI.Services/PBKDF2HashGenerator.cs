using System;
using System.Security.Cryptography;

namespace MusicTrackAPI.Services
{
	public static class PBKDF2HashGenerator
	{
        public const int SALT_SIZE = 24;
        public const int HASH_SIZE = 24; 
        public const int ITERATIONS = 100000; 

        public static string CreateHash(string input)
        {
            // Generate a salt
            
            byte[] salt = new byte[SALT_SIZE];

            RandomNumberGenerator.Create().GetBytes(salt);

            // Generate the hash
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS);
            return pbkdf2.GetBytes(HASH_SIZE).ToString();
        }
    }
}


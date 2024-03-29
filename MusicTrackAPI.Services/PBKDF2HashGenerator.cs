﻿using System.Security.Cryptography;
using MusicTrackAPI.Services.Model;

namespace MusicTrackAPI.Services
{
    public static class PBKDF2HashGenerator
    {
        public const int SALT_SIZE = 24;
        public const int HASH_SIZE = 24;
        public const int ITERATIONS = 100000;

        public static HashResult CreateHash(string input)
        {
            byte[] salt = new byte[SALT_SIZE];

            RandomNumberGenerator.Create().GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS);
            return new HashResult
            {
                Hash = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE)),
                Salt = Convert.ToBase64String(salt)
            };

        }

        public static bool VerifyHash(string input, string oldPassword, string salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, Convert.FromBase64String(salt), ITERATIONS);

            return Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE)) == oldPassword;
        }
    }
}


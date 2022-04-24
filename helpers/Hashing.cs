using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace JMR.helpers
{
    public class Hashing
    {
        public static byte[] generateSalt(){
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        return salt;
        }
        public static string generateHash(byte[] salt, string password){
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32));
            return hashed;
        }
    }
}
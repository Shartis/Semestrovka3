using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services.Implementations
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            var hashBuilder = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                var result = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                foreach (var b in result)
                    hashBuilder.Append(b.ToString("x2"));
            }

            return hashBuilder.ToString();
        }
    }
}

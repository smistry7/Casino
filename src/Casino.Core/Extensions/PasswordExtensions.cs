using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Core.Extensions
{
    public static class PasswordExtensions
    {
        public static string Encrypt(this string unencrypted)
        {
            byte[] data = Encoding.ASCII.GetBytes(unencrypted);
            var encryptor = SHA256.Create();
            data = encryptor.ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}


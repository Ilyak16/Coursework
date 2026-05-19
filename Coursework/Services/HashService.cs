using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Services
{
    public static class HashService
    {
        public static string ComputeSha512(
            string input)
        {
            using SHA512 sha =
                SHA512.Create();

            byte[] bytes =
                sha.ComputeHash(
                    Encoding.UTF8.GetBytes(input));

            StringBuilder builder =
                new();

            foreach (byte b in bytes)
            {
                builder.Append(
                    b.ToString("x2"));
            }

            return builder.ToString();
        }

        public static bool IsHash(
            string input)
        {
            return input.Length == 128;
        }
    }
}

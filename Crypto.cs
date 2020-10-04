using System;
using System.Security.Cryptography;
using System.Text;

namespace FacileDLL
{
    /// <summary>
    /// Хэширует строку
    /// </summary>
    public static class Crypto
    {
        /// <summary>
        /// Хэширует по алгоритму MD5
        /// </summary>
        /// <param name="data">Строка, которую необходимо хэшировать</param>
        /// <returns>Хэшированная строка</returns>
        public static string HashMD5(string data)
            => Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(data)));

        /// <summary>
        /// Хэширует по алгоритму SHA256
        /// </summary>
        /// <param name="data">Строка, которую необходимо хэшировать</param>
        /// <returns>Хэшированная строка</returns>
        public static string HashSHA256(string data)
            => Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(data)));
    }
}

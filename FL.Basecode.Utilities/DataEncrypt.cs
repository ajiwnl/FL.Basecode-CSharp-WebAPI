using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FL.Basecode.Utilities
{
    public static class DataEncrypt
    {
        // 32-byte (256-bit) key — you can store securely in configuration or environment variable
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("YourSuperSecretKeyOf32Chars!!!!!"); // must be 32 chars

        /// <summary>
        /// Encrypt plaintext using AES-256-CBC with a random IV.
        /// The returned string contains IV + ciphertext, base64 encoded.
        /// </summary>
        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Generate random IV for each encryption
            aes.GenerateIV();
            byte[] iv = aes.IV;

            using MemoryStream memoryStream = new();
            // Prepend IV to the output
            memoryStream.Write(iv, 0, iv.Length);

            using (CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
            }

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        /// <summary>
        /// Decrypt AES ciphertext (base64) which includes IV + encrypted data.
        /// </summary>
        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytesWithIv = Convert.FromBase64String(cipherText);

            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Extract IV from the first 16 bytes
            byte[] iv = new byte[16];
            Array.Copy(cipherBytesWithIv, 0, iv, 0, iv.Length);
            aes.IV = iv;

            // Ciphertext starts after the IV
            byte[] cipherBytes = new byte[cipherBytesWithIv.Length - iv.Length];
            Array.Copy(cipherBytesWithIv, iv.Length, cipherBytes, 0, cipherBytes.Length);

            using MemoryStream memoryStream = new(cipherBytes);
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader reader = new(cryptoStream);

            return reader.ReadToEnd();
        }
    }
}

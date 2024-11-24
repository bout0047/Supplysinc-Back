using System;
using System.Security.Cryptography;
using System.Text;

namespace SupplySyncBackend.Utilities
{
    public static class EncryptionUtility
    {
        private static readonly string Key = "YourSecureKey123!"; // Replace with a secure key

        public static string Encrypt(string text)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key.PadRight(32).Substring(0, 32));
            aes.IV = new byte[16]; // Initialization vector

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using var writer = new StreamWriter(cryptoStream);

            writer.Write(text);
            writer.Close();

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string Decrypt(string encryptedText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key.PadRight(32).Substring(0, 32));
            aes.IV = new byte[16]; // Initialization vector

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText));
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }
    }
}

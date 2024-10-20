using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        byte[] encryptionKey = new byte[32];
        byte[] iv = new byte[16];

        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(encryptionKey);
            foreach (byte b in encryptionKey)
            {
                Console.Write($"{b},");
            }
            Console.WriteLine();

            random.GetBytes(iv);
            foreach (byte b in iv)
            {
                Console.Write($"{b},");
            }
            Console.WriteLine();
        }

        string dataToEncrypt = "This is the data to encrypt";
        byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(dataToEncrypt);
        foreach (byte b in bytesToEncrypt)
        {
            Console.Write($"{b},");
        }
        Console.WriteLine();

        using (AesManaged aes = new AesManaged())
        {
            aes.Key = encryptionKey;
            aes.IV = iv;

            using (MemoryStream encryptedStream = new MemoryStream())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor();
                using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] encryptedBytes = encryptedStream.ToArray();
                    string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
                    Console.WriteLine(encryptedBase64);
                }
            }
        }
    }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

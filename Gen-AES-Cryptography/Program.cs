using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        byte[] aesKey2 = StringToByteArray("28b87ff2357a9af9107b0a018203b2cc1cf042c510b373b949d8cd4239cc3b28");
        // Generate a random AES key
        byte[] aesKey = GenerateRandomKey(32); // 256 bits
        Console.Write("aseKey      : ");
        Console.WriteLine(ByteArrayToString(aesKey));

        byte[] iv2 =  StringToByteArray("71cb188b452854c84ad7ec22817081e1");
        // Generate a random initialization vector (IV)
        byte[] iv = GenerateRandomKey(16); // 128 bits
        Console.Write("iv          : ");
        Console.WriteLine(ByteArrayToString(iv));

        Console.WriteLine($"aesKey2.Len={aesKey2.Length}, iv2.Len={iv2.Length}, aesKey.Len={aesKey.Length}, iv.Len={iv.Length}");
        byte[] encryptedKey2 = EncryptAesKey(aesKey2, iv2);
        Console.Write("encryptedKey2: ");
        Console.WriteLine(ByteArrayToString(encryptedKey2));
        // Encrypt the AES key
        byte[] encryptedKey = EncryptAesKey(aesKey, iv);
        Console.Write("encryptedKey: ");
        Console.WriteLine(ByteArrayToString(encryptedKey));

        // Print the encrypted key
        Console.WriteLine("Encrypted AES Key: " + Convert.ToBase64String(encryptedKey));
    }

    private static byte[] GenerateRandomKey(int size)
    {
        byte[] key = new byte[size];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(key);
        }
        return key;
    }

    private static byte[] EncryptAesKey(byte[] key, byte[] iv)
    {
        using (AesManaged aes = new AesManaged())
        {
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.GenerateIV();
            byte[] encryptedKey;

            using (ICryptoTransform encryptor = aes.CreateEncryptor(key, iv))
            {
                encryptedKey = encryptor.TransformFinalBlock(key, 0, key.Length);
            }

            byte[] result = new byte[iv.Length + encryptedKey.Length];
            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(encryptedKey, 0, result, iv.Length, encryptedKey.Length);

            return result;
        }
    }
    public static string ByteArrayToString(byte[] ba)
    {
    StringBuilder hex = new StringBuilder(ba.Length * 2);
    foreach (byte b in ba)
        hex.AppendFormat("{0:x2}", b);
    return hex.ToString();
    }
    public static byte[] StringToByteArray(string hex)
    {
        int length = hex.Length;
        byte[] bytes = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }

}


// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

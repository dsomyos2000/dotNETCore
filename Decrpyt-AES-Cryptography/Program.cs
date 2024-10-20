using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
         string sencKey = "oJ+TfslK/CZJJWKuMhN9F7GwODE2DjtCfVVy0XBmIl5ATde7H2d6nNXcvIv4czoVlSK9qT6xQxowoUMEGx+LRA==";
         string sencryptedKey = "a09f937ec94afc26492562ae32137d17b1b03831360e3b427d5572d17066225e404dd7bb1f677a9cd5dcbc8bf8733a159522bda93eb1431a30a143041b1f8b44";
         string siv = "7565285b877ca24ffa7bff04b6924843";
         byte[] encryptedKey = StringToByteArray(sencKey);
         byte[] encKey = StringToByteArray(sencryptedKey);
         byte[] iv = StringToByteArray(siv);
         byte[] after = DecryptAesKey(encryptedKey, encKey, iv);
         Console.WriteLine(Encoding.UTF8.GetString(after));
    }
    private static byte[] DecryptAesKey(byte[] encryptedKey, byte[] aesKey, byte[] iv)
    {
        using (AesManaged aes = new AesManaged())
        {
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] decryptedKey;

            using (ICryptoTransform decryptor = aes.CreateDecryptor(aesKey, iv))
            {
                decryptedKey = decryptor.TransformFinalBlock(encryptedKey, 0, encryptedKey.Length);
            }

            return decryptedKey;
        }
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

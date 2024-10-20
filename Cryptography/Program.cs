using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        string encryptedString = "e8eccc3f2fb504acf99c19515d855d47f5a6a9c604fb859bc27e2e37146fa8e3";
        byte[] encryptedBytes = StringToByteArray(encryptedString);

        using (Aes aes = Aes.Create())
        {
            aes.KeySize = 256;
            aes.GenerateKey();
            aes.BlockSize = 128;
            aes.IV = Encoding.UTF8.GetBytes("TruePayNext12345".PadRight(16, '\0'));

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            string decryptedString = Encoding.UTF8.GetString(decryptedBytes);
            Console.WriteLine("Decrypted String: " + decryptedString);
        }
    }

    private static byte[] StringToByteArray(string hex)
    {
        int numberChars = hex.Length / 2;
        byte[] bytes = new byte[numberChars];
        using (var sr = new StringReader(hex))
        {
            for (int i = 0; i < numberChars; i++)
                bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
        }
        return bytes;
    }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

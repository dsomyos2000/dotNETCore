using System;
using System.Text;
using System.Security.Cryptography;

byte[] encryptionKey = new byte[] {100,141,161,56,247,210,126,169,108,194,220,11,102,86,138,144,175,72,168,19,2,173,48,6,237,68,19,98,177,123,133,58};
byte[] iv = new byte[] {170,223,211,205,200,225,176,163,61,46,229,17,204,219,231,106} ;
string encryptedText = "t31nyfsdsJ+fjKjH1Bp88eFGEHKzr/qXeC6qO6cHrzo=";

Console.WriteLine($"Source Encrypted: `{encryptedText}`");
byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
using (Aes aes = Aes.Create()) {
    aes.Key = encryptionKey;
    aes.IV = iv;
    using (ICryptoTransform decryptor = aes.CreateDecryptor()) {
        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
        Console.WriteLine($"Decrypted Text: `{decryptedText}`");
    }
}

Console.Write("Encrypt Key: ");
foreach (byte b in encryptionKey ) { Console.Write($"{b},"); }
Console.Write("\nIV: ");
foreach (byte b in iv) { Console.Write($"{b},"); }
Console.WriteLine();

foreach (var item in iv.Select(b => b / 2).ToArray()) { Console.Write($"{item},"); } Console.WriteLine();
foreach (var item in iv.Where(x => x < 100).ToArray()) { Console.Write($"{item},"); } Console.WriteLine();
int[] arrInt = new int[] {170,223,211,205,200,225,176,163,61,46,229,17,204,219,231,106} ;
Console.WriteLine( arrInt.Aggregate((x, y) => x + y) );
//arrInt.Select(x => Console.WriteLine(x) );

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
IEnumerable<int> squares = numbers.Select(x => x * x);

string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };
var query = fruits.Select((fruit, index) => new { index, str = fruit.Substring(0, fruit.Length > index ? index+1 : fruit.Length) });
foreach (var obj in query) { Console.WriteLine("{0}", obj); }

List<int> Scores = new List<int>() { 97, 92, 81, 60 };
IEnumerable<int> queryHighScores = from score in Scores where score > 80 select score;
foreach (int i in queryHighScores) { Console.Write(i + " "); } Console.WriteLine();

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//100,141,161,56,247,210,126,169,108,194,220,11,102,86,138,144,175,72,168,19,2,173,48,6,237,68,19,98,177,123,133,58,
//170,223,211,205,200,225,176,163,61,46,229,17,204,219,231,106,
//84,104,105,115,32,105,115,32,116,104,101,32,100,97,116,97,32,116,111,32,101,110,99,114,121,112,116,
//t31nyfsdsJ+fjKjH1Bp88eFGEHKzr/qXeC6qO6cHrzo=

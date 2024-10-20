Dictionary<string, int> myDictionary = new Dictionary<string, int>();
Dictionary<int, int> myDictionary2 = new Dictionary<int, int>();
Dictionary<int, int[]> myDictionary3 = new Dictionary<int, int[]>();
Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();

// Adding key-value pairs to the dictionary
myDictionary.Add("apple", 5);
myDictionary.Add("banana", 3);
myDictionary.Add("orange", 7);

// Accessing values by key
int appleCount = myDictionary["apple"]; // 5
int bananaCount = myDictionary["banana"]; // 3
int orangeCount = myDictionary["orange"]; // 7

// Modifying values
myDictionary["apple"] = 10; // Update the value of "apple" to 10

// Removing key-value pairs
myDictionary.Remove("banana"); // Remove the key-value pair with key "banana"

// Checking if a key exists
bool containsApple = myDictionary.ContainsKey("apple"); // true
bool containsBanana = myDictionary.ContainsKey("banana"); // false

// Iterating over key-value pairs
foreach (KeyValuePair<string, int> kvp in myDictionary)
{
    string key = kvp.Key;
    int value = kvp.Value;
    Console.WriteLine($"Key: {key}, Value: {value}");
}
//-------------------
myDictionary2.Add(1, 10);
myDictionary2.Add(2, 20);
myDictionary2.Add(3, 30);
Console.WriteLine($"myDictionary2[2]={myDictionary2[2]}");
int value2;
if (myDictionary2.TryGetValue(4, out value2)) {
    Console.WriteLine($"Found: myDictionary2[4]={myDictionary2[4]}");
} else {
    Console.WriteLine("Not found: myDictionary[4]");
}
foreach (KeyValuePair<int, int> pair in myDictionary2)
{
    int key = pair.Key;
    int value = pair.Value;
    Console.WriteLine($"{key} - {value}");
}

myDictionary3.Add(1, new int[] { 1, 2, 3 });
myDictionary3.Add(2, new int[] { 4, 5, 6, 7, 8, 9 });

Console.WriteLine($"myDictionary3.ContainsKey(1)={myDictionary3.ContainsKey(1)}");
foreach (KeyValuePair<int, int[]> pair in myDictionary3) {
    Console.Write($"{pair.Key}: ");
    foreach(int x in pair.Value) {
        Console.Write($"{x},");
    }
    Console.WriteLine();
}

dictionary.Add(1, new List<int> { 10, 20, 30 });
dictionary.Add(2, new List<int> { 40, 50 });
dictionary.Add(3, new List<int> { 60 });
List<int> valuesForKey1 = dictionary[1];
valuesForKey1.Add(40);

foreach (KeyValuePair<int, List<int>> pair in dictionary)
{
    int key = pair.Key;
    List<int> values = pair.Value;

    Console.Write($"Key: `{key}` -> ");
    foreach (int value in values)
    {
        Console.Write($"{value},");
    }
    Console.WriteLine();
}
Console.WriteLine($"");

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

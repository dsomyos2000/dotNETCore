List<string> names = new List<string>();
names.Add("Bruce");
names.Add("Alfred");
names.Add("Tim");
names.Add("Richard");

// Display the contents of the list using the Print method.
names.ForEach(Print);  Console.WriteLine("\n---------------");
names.ForEach(Console.WriteLine); Console.WriteLine("---------------");

// The following demonstrates the anonymous method feature of C#
// to display the contents of the list to the console.
names.ForEach(delegate (string name){
    Console.WriteLine(name);
});

void Print(string s)
{
    Console.Write($"{s}, ");
}
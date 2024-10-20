Dictionary<string, int> personAges = new Dictionary<string, int>
{
    { "John", 25 },
    { "Emily", 30 },
    { "Michael", 35 },
    { "Sarah", 28 }
};

personAges
    .AsParallel()
    .ForAll(pair => 
    { 
        Console.WriteLine($"1# {pair.Key} is {pair.Value} years old.");
    });

foreach (var (name, age) in personAges)
{
    Console.WriteLine($"2# {name} is {age} years old.");
}

foreach (KeyValuePair<string, int> kvp in personAges) {
    Console.WriteLine($"3# {kvp.Key} is {kvp.Value} years old.");
}
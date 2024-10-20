using System;

namespace Tutlane
{
     class User
     {
        public string Name { get; set; }
        public string Location { get; set; }
     }
     class Program
     {
         static void Main(string[] args)
         {
             User u = new User();
             u.Name = "Suresh Dasari";
             u.Location = "Hyderabad";
             Console.WriteLine("Name: " + u.Name);
             Console.WriteLine("Location: " + u.Location);
             Console.WriteLine("\nPress Enter Key to Exit..");
             Console.ReadLine();
         }
     }
}
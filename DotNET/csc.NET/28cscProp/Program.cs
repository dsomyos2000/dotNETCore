using System;

namespace Tutlane
{
     class User
     {
        private string location;
        private string name = "Suresh Dasari";
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public string Name
        {
           get
           {
               return name.ToUpper();
           }
           set
           {
               if (value == "Suresh")
                  name = value;
           }
        }
     }
     class Program
     {
        static void Main(string[] args)
        {
            User u = new User();
            // set accessor will invoke
            u.Name = "Rohini";
            // set accessor will invoke
            u.Location = "Hyderabad";
            // get accessor will invoke
            Console.WriteLine("Name: " + u.Name);
            // get accessor will invoke
            Console.WriteLine("Location: " + u.Location);
            Console.WriteLine("\nPress Enter Key to Exit..");
            Console.ReadLine();
        }
     }
}
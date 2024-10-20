using System;

class Student
{
  public int Age { get; set; }
  public string Name { get; private set; }

  public Student() // Empty constructor
  {}

  public Student(int age, string name)
  {
    Age = age; // Work with Age as it is a field
    Name = name;
  }
  public void SetName(string name) { Name = name; }
}

class Program
{
  public static void Main()
  {
    // Using object initializer
    var student = new Student (20, "John");

    // Using classic approach
    var student2 = new Student();
    student2.Age = 21;      // Work with Age just like a public field
    //student2.Name = "Johny"; // ERROR: setter for the Name is private
    student2.SetName("Johny");

    // Using a constructor that sets age
    var student3 = new Student(22, "Johnatan");

    Console.WriteLine("Name={0}, Age={1}.",student.Name,student.Age);
    Console.WriteLine("Name={0}, Age={1}.",student2.Name,student2.Age);
    Console.WriteLine("Name={0}, Age={1}.",student3.Name,student3.Age);
  }
}
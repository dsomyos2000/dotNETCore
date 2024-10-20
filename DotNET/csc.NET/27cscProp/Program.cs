using System;
using SampleLibrary;

class Person
{
  private string name; // field
  public string Name   // property
  {
    get { return "<"+name+">"; }
    set { name = value; }
  }
}

class Program
{
  static void Main(string[] args)
  {
    Person myObj = new Person();
    myObj.Name = "Liam";
    Console.WriteLine(myObj.Name);

    SampleLibrary.Person myObj2 = new SampleLibrary.Person();
    myObj2.Name = "Liam2";
    Console.WriteLine(myObj2.Name);
  }
}

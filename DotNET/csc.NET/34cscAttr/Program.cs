// C# program to display the custom attributes
using System;
using System.Reflection;
using System.Collections.Generic;

// Defining a Custom attribute class
class NewAttribute : Attribute {

	// Private fields
	private string title;
	private string description;

	// Parameterised Constructor
	public NewAttribute(string t, string d)
	{
		title = t;
		description = d;
	}

	// Method to show the Fields
	// of the NewAttribute
	// using reflection
	public static void AttributeDisplay(Type classType)
	{
		Console.WriteLine("Methods of class {0}", classType.Name);

		// Array to store all methods of a class
		// to which the attribute may be applied

		MethodInfo[] methods = classType.GetMethods();

		// for loop to read through all methods

		for (int i = 0; i < methods.GetLength(0); i++) {

			// Creating object array to receive
			// method attributes returned
			// by the GetCustomAttributes method

			object[] attributesArray = methods[i].GetCustomAttributes(true);

			// foreach loop to read through
			// all attributes of the method
			foreach(Attribute item in attributesArray)
			{
				if (item is NewAttribute) {

					// Display the fields of the NewAttribute
					NewAttribute attributeObject = (NewAttribute)item;
					Console.WriteLine("{0} - {1}, {2} ", methods[i].Name,
					attributeObject.title, attributeObject.description);
				}
			}
		}
	}
}

// Class Employer
class Employer {

	// Fields of Employer
	int id;
	string name;

	// Constructor
	public Employer(int i, string n)
	{
		id = i;
		name = n;
	}

	// Applying the custom attribute
	// NewAttribute to the getId method
	[NewAttribute("Accessor", "Gives value of Employer Id")] public int getId()
	{
		return id;
	}

	// Applying the custom attribute
	// NewAttribute to the getName method
	[NewAttribute("Accessor", "Gives value of Employer Name")] public string getName()
	{
		return name;
	}
}

// Class Employee
class Employee {

	// Fields of Employee
	int id;
	string name;

	public Employee(int i, string n)
	{
		id = i;
		name = n;
	}

	// Applying the custom
	// attribute NewAttribute
	// to the getId method
	[NewAttribute("Accessor", "Gives value of Employee Id")] public int getId()
	{
		return id;
	}

	// Applying the custom attribute
	// NewAttribute to the getName method
	[NewAttribute("Accessor", "Gives value of Employee Name")] public string getName()
	{
		return name;
	}
}

class Program {

	// Main Method
	static void Main(string[] args)
	{

		// Calling the AttributeDisplay
		// method using the class name
		// since it is a static method
		NewAttribute.AttributeDisplay(typeof(Employer));

		Console.WriteLine();

		NewAttribute.AttributeDisplay(typeof(Employee));
	}
}

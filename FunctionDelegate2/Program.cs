using System;

// Declare a delegate type
delegate void MyDelegate(string message);

class Program
{
    static void Main(string[] args)
    {
        MyDelegate myDelegate = new MyDelegate(fn_ShowMessage); // Create an instance of the delegate
        myDelegate("Hello, delegates!"); // Invoke the delegate
        myDelegate = new MyDelegate(fn_ShowAnotherMessage);  // Assign a different method to the delegate
        myDelegate("This is another message!");  // Invoke the delegate again
        fn_ProcessMessage("Process completed.", myDelegate);  // Use the delegate as a callback
    }

    static void fn_ShowMessage(string message)
    {
        Console.WriteLine("Message: " + message);
    }

    static void fn_ShowAnotherMessage(string message)
    {
        Console.WriteLine("Another message: " + message);
    }

    static void fn_ProcessMessage(string message, MyDelegate callback)
    {
        Console.WriteLine("Processing message: " + message);
        callback("Callback message");
    }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

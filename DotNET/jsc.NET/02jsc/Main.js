/*
  To Compile:
    PATH\\TO\\jsc.exe QuoteOfTheDay.js
  
  Example this Code is based on:
     https://github.com/dotnet/core/blob/master/samples/qotd/Program.cs
 */
import System;
import System.IO;

function Main(args : String[]) : void
{
	if (args.length <=1)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("You must specify a quotes file.");
		Console.ResetColor();
		return;
	}
	var quotes = File.ReadAllLines(args[1]);
	var randomQuote:String = quotes[new Random().Next(0, quotes.Length-1)];
		
	Console.WriteLine("[QOTD]: {0}", randomQuote);
};

// Run the Program:
var myArguments : String[] = Environment.GetCommandLineArgs();
Main(myArguments);
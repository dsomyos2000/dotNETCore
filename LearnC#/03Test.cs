using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Create a new process instance
        Process process = new Process();

        // Set the start info for the process
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "csc.exe";                           // Specify the path to csc.exe
        startInfo.Arguments = "/out:02Test.exe 02Test.cs"; // Specify the arguments for csc.exe
        startInfo.RedirectStandardOutput = true;              // Redirect the standard output
        startInfo.UseShellExecute = false;                       // Do not use the shell to execute the process

        // Start the process
        process.StartInfo = startInfo;
        process.Start();

        // Read the output from the process
        string output = process.StandardOutput.ReadToEnd();

        // Wait for the process to exit
        process.WaitForExit();

        // Display the output
        Console.WriteLine(output);
    }
}

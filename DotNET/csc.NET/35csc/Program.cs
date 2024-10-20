using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DemoApplication
{
 class Program
 { 
  static void Main(string[] args) 
  {
   Console.WriteLine(@"Hello World {0}",args[0]);
   Console.WriteLine(string.Format("Hello World {0}",args[0]));

   //Console.ReadKey();
  }
 }
}
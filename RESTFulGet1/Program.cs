using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientStatus
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var defurl = "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_GETPROFILE.v1/?thai_id=696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e285533&employee_id=00000371";
            var prcsurl = "";
            int validURL = 0;
            if (args.Length == 0) {
                Console.WriteLine(defurl);
            } else {
                if ( args.Length == 2 && args[0] == "." && args[1] == "371") { 
                    prcsurl = defurl; 
                    validURL = 1;
                } else if ( args.Length >= 1 && !args[0].StartsWith("http") ) { 
                    Console.WriteLine("Please specify URL.");
                    Console.WriteLine($"Example URL:- \n{defurl}");
                } else { 
                    prcsurl = args[0]; 
                    validURL = 1;
                }
                if ( validURL == 1) {
                    using var client = new HttpClient();
                    var result = await client.GetAsync(prcsurl);
                    Console.WriteLine(result.StatusCode);
                    var responseContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }

        }
    }
}
//
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

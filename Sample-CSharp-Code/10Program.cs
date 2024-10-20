//ChatGPT: Search 'Please provide Console App to consume PUT RESTFul API'
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://example.com/api/resource";
            var data = "{\"key\": \"value\"}";

            using (var client = new HttpClient())
            {
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PUT request successful");
                }
                else
                {
                    Console.WriteLine(quot;PUT request failed with status code {response.StatusCode}");
                }
            }
        }
    }
}

//ChatGPT: Search 'Please provide Console App to consume POST RESTFul API'
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://example.com/api/resource");
                var content = new StringContent("{\"key\":\"value\"}", System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
        }
    }
}

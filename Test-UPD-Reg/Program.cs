// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py");

        var jsonData = new
        {
            thai_id = "696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e28553300000371cp_axtra_public_co_ltd",
            employee_id = "00000371"
        };

        var httpContent = new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_EMPPROFILE.v1/", httpContent);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
}

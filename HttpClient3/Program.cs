// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py");
        var uri = new Uri("http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_EMPPROFILE.v1/");
        var content = new StringContent("{ \"thai_id\": \"696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e285533\", \"employee_id\" : \"00000371\" }", System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync(uri, content);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
}

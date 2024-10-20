// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
public class Program
{
    public static async Task Main(string[] args)
    {
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = ValidateCertificate;

        using var client = new HttpClient(handler);
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py");
        var uri = new Uri("https://10.81.1.44:8019/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/");
        var content = new StringContent("{ \"message\":  \"register complete\", \"code\":  \"00\", \"employee_id\":  \"00000371\" }", System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync(uri, content);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
    static bool ValidateCertificate(HttpRequestMessage request, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors errors)
    {
        // Ignore all certificate validation errors
        return true;
    }
}

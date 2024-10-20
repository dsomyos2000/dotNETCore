using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Newtonsoft.Json;
using Microsoft.AspNet.WebApi.Client;
using Microsoft.AspNetCore;

public class Program
{
    public class ApiSettings
    {
        public string AccessToken { get; set; }
        public string ApiUrl { get; set; }
    }
    public static async Task<string> GetAccessTokenAsync(string clientId, string clientSecret, string tokenUrl)
    {
        using (var client = new HttpClient())
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            });

            var response = await client.PostAsync(tokenUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<JObject>(responseString)["access_token"].ToString();

            return token;
        }
    }
    public static async Task<string> MakeApiRequestAsync(string apiUrl, string accessToken)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(apiUrl);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
    static async Task Main(string[] args)
    {
        var apiSettings = new ApiSettings
        {
            AccessToken = await GetAccessTokenAsync("your_client_id", "your_client_secret", "https://auth.example.com/token"),
            ApiUrl = "https://api.example.com/data"
        };

        var apiResponse = await MakeApiRequestAsync(apiSettings.ApiUrl, apiSettings.AccessToken);

        Console.WriteLine(apiResponse);
    }
    public Program() { AccessToken = "e8eccc3f2fb504acf99c19515d855d47f5a6a9c604fb859bc27e2e37146fa8e3"; }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
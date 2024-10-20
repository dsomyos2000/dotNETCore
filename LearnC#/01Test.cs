using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Create an instance of HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Send a GET request to the API endpoint
                HttpResponseMessage response = await client.GetAsync("https://api.example.com/endpoint");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Process the response data
                    Console.WriteLine(responseBody);
                }
                else
                {
                    // Handle the error response
                    Console.WriteLine("Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                Console.WriteLine("Exception: {ex.Message}");
            }
        }
    }
}

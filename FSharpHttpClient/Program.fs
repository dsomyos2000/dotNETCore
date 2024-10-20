
open System
open System.Net.Http
open System.Net.Http.Headers
open System.Text
open System.Threading.Tasks
open Newtonsoft.Json

[<EntryPoint>]
let main argv =
    async {
        let apiUrl = "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_GETPROFILE.v1/?thai_id=696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e285533&employee_id=00000371"
        let client = new HttpClient()
        client.DefaultRequestHeaders.Authorization <- new AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py")

        let! response = client.GetAsync(apiUrl) |> Async.AwaitTask
        let! responseContent = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        Console.WriteLine(responseContent)
    } |> Async.RunSynchronously
    0

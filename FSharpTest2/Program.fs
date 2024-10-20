// For more information see https://aka.ms/fsharp-console-apps
open System.Net.Http
open Newtonsoft.Json
open FSharp.Data
open Newtonsoft.Json

printfn "F# - FSharpTest2.cs"

let httpClient = new HttpClient()
httpClient.DefaultRequestHeaders.Authorization <- new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py")
type RecordType = {
        thai_id: string
        employee_id: string
}
let data:  RecordType = { 
        thai_id="696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e28553300000371cp_axtra_public_co_ltd";
        employee_id = "00000371"
}

let jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(data)

let httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json")

let response = httpClient.PostAsync("http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_EMPPROFILE.v1/", httpContent).Result
let responseContent = response.Content.ReadAsStringAsync().Result

printfn "%s" "==Response Message=="
printfn "%s" responseContent

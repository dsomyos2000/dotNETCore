open System
open RestSharp
open System.Configuration
open Newtonsoft.Json.Linq
open System.Reflection

let HostURL = "http://10.81.1.44:8018"
let DataURL = "/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/"
let Authtoken = "UFNUUE46QywySllIbl9neTRSU0py"
let client = new RestSharp.RestClient($"{HostURL}{DataURL}")
let request = new RestSharp.RestRequest()
request.Method <- RestSharp.Method.Post

request.AddHeader("Authorization", $"Basic {Authtoken}")
let requestBody = "{\"employee_id\": \"00000371\",\"code\": \"00\",\"message\": \"register complete\"}"
request.AddParameter("application/json", requestBody, ParameterType.RequestBody)

try
    let response = client.Execute(request)
    let obj = JObject.Parse(response.Content)

    Console.WriteLine($"Data: {response.Content}")
with
    | ex -> 
        let ex1 = ex.ToString()
        Console.WriteLine($"Exception: {ex1}")

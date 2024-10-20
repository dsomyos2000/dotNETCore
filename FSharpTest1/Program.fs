// For more information see https://aka.ms/fsharp-console-apps
//printfn "Hello from F#"
open System.Net.Http

let httpClient = new HttpClient()
let response = httpClient.GetAsync("http://ip.jsontest.com/").Result
let content = response.Content.ReadAsStringAsync().Result

printfn "Response: %s" content

// For more information see https://aka.ms/fsharp-console-apps
//printfn "Hello from F#"
open System
open System.Net
open Newtonsoft.Json.Linq
open System.Security.Cryptography

let PAYNEXT_UPDATEREGISTER = "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/"
let PAYNEXT_EMPPROFILE = "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_EMPPROFILE.v1/"

let listener = new HttpListener()
listener.Prefixes.Add("http://localhost:8080/")
listener.Prefixes.Add("http://127.0.0.1:8080/")
//listener.Prefixes.Add("http://+:8080/") /*Require Administrator*/
listener.Start()

printfn "Listening for requests..."
let uri0 = new Uri(PAYNEXT_UPDATEREGISTER)
let uri1 = new Uri(PAYNEXT_EMPPROFILE)
let maxNUM = 0xff00000AAUL
let mutable gCnt = maxNUM
let mutable nRound = 0
let mutable flagCont = true

while listener.IsListening && flagCont do
    if gCnt > 0UL then
        gCnt <- gCnt - 1UL
    else
        gCnt <- maxNUM
        nRound <- nRound + 1

    try
        let context = listener.GetContext()
        let request = context.Request
        let response = context.Response

        for headerName in request.Headers.AllKeys do
            let headerValue = request.Headers.[headerName]
            if headerName = "Authorization" || headerName = "Content-Type" then
                Console.Write("✔️")
                Console.Write("{0}: {1}", headerName, headerValue)

        Console.WriteLine("")
        let strURL = sprintf "%O" request.Url
        let mutable strHost = strURL
        let mutable strApi = strURL
        let mutable strQry = strURL
        let strRoute = "/api/v1/update-status"
        let posOfapi = strURL.IndexOf(strRoute)
        let empRoute = "/api/v1/employee-profile"
        let posOfemp = strURL.IndexOf(empRoute)
        let mutable responseString = ""

        if posOfapi > 0 then
            // Update-Status
            use body = request.InputStream
            use reader = new System.IO.StreamReader(body, request.ContentEncoding)
            let requestBody = reader.ReadToEnd()

            if requestBody.Length >= 7 then
                Console.Write("[{0}]", requestBody.Length)
                Console.WriteLine(requestBody.Replace("\n", "").Replace("\r", "").Replace("  ", " "))

                let jsonBody = JObject.Parse(requestBody)
                let json = JObject()
                json.Add("employee_id", jsonBody.["employee_id"])
                let jsonStat = jsonBody.["status"] :?> JObject
                json.Add("code", jsonStat.["code"])
                json.Add("message", jsonStat.["message"])
                Console.WriteLine(json.ToString().Replace("\n", "").Replace("\r", "").Replace("  ", " "))

                strApi <- strURL.Substring(posOfapi, strURL.Length - posOfapi)
                strHost <- strURL.Replace(strApi, "")
                strQry <- strURL.Replace(strHost + strRoute, "")

                if request.HttpMethod = "POST" then
                    use client = new HttpClient()
                    let newRequestBody = json.ToString()
                    client.DefaultRequestHeaders.Authorization <- new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py")
                    let! psresponse = client.PostAsync(uri0, new StringContent(newRequestBody)) |> Async.AwaitTask
                    let! responseContent = psresponse.Content.ReadAsStringAsync() |> Async.AwaitTask
                    Console.WriteLine(responseContent)

                    if responseContent.Length >= 7 then
                        response.ContentType <- "application/json"
                        responseString <- responseContent
                    else
                        response.ContentType <- "application/json"
                        responseString <- sprintf "{\"code\": \"DATA_NOT_FOUND\",\"message\": \"User not found\",\"ref⁴\": %O; %O,\"HttpMethod\": \"%s\"}" gCnt responseContent request.HttpMethod
                elif request.HttpMethod = "GET" then
                    responseString <- sprintf "{\"code\": \"SUCCESS\",\"message\": \"Success\",\"ref⁵\": %O}" gCnt
                else
                    response.ContentType <- "text/plain"
                    responseString <- sprintf "%s - %s; %s; %s; %O(%O)" request.HttpMethod strHost strRoute strQry gCnt nRound
            else
                if request.HttpMethod = "GET" then
                    use client = new HttpClient()
                    client.DefaultRequestHeaders.Authorization <- new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py")
                    let content = new StringContent("{ \"message\":  \"register complete\", \"code\":  \"00\", \"employee_id\":  \"00000371\" }", System.Text.Encoding.UTF8, "application/json")
                    let! psresponse = client.PostAsync(uri0, content) |> Async.AwaitTask
                    let! responseContent = psresponse.Content.ReadAsStringAsync() |> Async.AwaitTask
                    Console.WriteLine(responseContent)

                    if responseContent.Length >= 7 then
                        responseString <- responseContent
                        response.ContentType <- "text/plain"
                    else
                        responseString <- sprintf "Lenght of response not JSON format! Response=[%s]" responseContent
                        response.ContentType <- "text/plain"
                else
                    responseString <- sprintf "{\"code\": \"DATA_NOT_FOUND\",\"message\": \"User not found\",\"ref⁶\": %O,\"HttpMethod\": \"%s\"}" gCnt request.HttpMethod
                    response.ContentType <- "application/json"
        elif posOfemp > 0 then
            // Employee-Profile
            use body = request.InputStream
            use reader = new System.IO.StreamReader(body, request.ContentEncoding)
            let requestBody = reader.ReadToEnd()

            if requestBody.Length >= 7 then
                Console.Write("<%O>", requestBody.Length)
                Console.WriteLine(requestBody.Replace("\n", "").Replace("\r", "").Replace("  ", " "))

                strApi <- strURL.Substring(posOfemp, strURL.Length - posOfemp)
                strHost <- strURL.Replace(strApi, "")
                strQry <- strURL.Replace(strHost + empRoute, "")

                if request.HttpMethod = "POST" then
                    use client = new HttpClient()
                    client.DefaultRequestHeaders.Authorization <- new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py")
                    let! psresponse = client.PostAsync(uri1, new StringContent(requestBody)) |> Async.AwaitTask
                    let! responseContent = psresponse.Content.ReadAsStringAsync() |> Async.AwaitTask

                    if responseContent.Length >= 7 then
                        responseString <- responseContent
                        response.ContentType <- "application/json"
                    else
                        responseString <- sprintf "{\"ref⁷\":%O,\"code\": \"DATA_NOT_FOUND\",\"message\": \"Profile not found\"}" gCnt
                        response.ContentType <- "application/json"
                else
                    response.ContentType <- "text/plain"
                    responseString <- sprintf "%s - %s; %s; %s; %O(%O)" request.HttpMethod strHost empRoute strQry gCnt nRound
            else
                responseString <- sprintf "{\"code\": \"DATA_NOT_FOUND\",\"message\": \"User not found\",\"ref⁸\": %O,\"HttpMethod\": \"%s\"}" gCnt request.HttpMethod
                response.ContentType <- "application/json"
        elif strURL.EndsWith("/end") then
            responseString <- "End."
            flagCont <- false

        Console.WriteLine("Received request: %s %s" request.HttpMethod strApi)

        let buffer = System.Text.Encoding.UTF8.GetBytes(responseString)
        response.ContentLength64 <- int64 buffer.Length
        response.OutputStream.Write(buffer, 0, buffer.Length)
        response.OutputStream.Close()
    with
        | e -> Console.WriteLine(e.Message)

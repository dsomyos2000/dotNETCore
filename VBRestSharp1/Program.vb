Imports System
Imports RestSharp
Imports System.Configuration
Imports Newtonsoft.Json.Linq
Imports System.Reflection

Module Program
    Sub Main(args As String())
        Dim HostURL As String = "http://10.81.1.44:8018"
        Dim DataURL As String = "/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/"
        Dim Authtoken As String = "UFNUUE46QywySllIbl9neTRSU0py"
        Dim client As New RestSharp.RestClient($"{HostURL}{DataURL}")
        Dim request As New RestSharp.RestRequest()
        request.Method = RestSharp.Method.Post

        request.AddHeader("Authorization", "Basic " + Authtoken)
        Dim requestBody As String = "{""employee_id"": ""00000371"",""code"": ""00"",""message"": ""register complete""}"
        request.AddParameter("application/json", requestBody, ParameterType.RequestBody)

        Try
            Dim response = client.Execute(request)
            Dim obj = JObject.Parse(response.Content)

            Console.WriteLine("Data: " + response.Content)
            'Console.ReadLine()
        Catch ex As Exception
            Dim ex1 As String = ex.ToString()
            Console.WriteLine($"Exception: {ex1}")
        End Try
    End Sub
End Module

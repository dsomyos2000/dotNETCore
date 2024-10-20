Imports System
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Module Program
    Sub Main(args As String())
        Dim client As New HttpClient()
        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py")

        Dim jsonData = New With {
            .thai_id = "696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e28553300000371cp_axtra_public_co_ltd",
            .employee_id = "00000371"
        }

        Dim httpContent = New StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8, "application/json")
        Dim response = client.PostAsync("http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_EMPPROFILE.v1/", httpContent).Result
        Dim responseContent = response.Content.ReadAsStringAsync().Result
        Console.WriteLine(responseContent)
    End Sub
End Module

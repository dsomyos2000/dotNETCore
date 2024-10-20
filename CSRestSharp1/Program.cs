using System;
using RestSharp;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Reflection;

string HostURL = "http://10.81.1.44:8018";
string DataURL = "/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/";
string Authtoken = "UFNUUE46QywySllIbl9neTRSU0py";
var client = new RestSharp.RestClient(HostURL);
var request = new RestSharp.RestRequest(DataURL,RestSharp.Method.Post);

request.AddHeader("Authorization", "Basic " + Authtoken);
string requestBody = "{\"employee_id\": \"00000371\",\"code\": \"00\",\"message\": \"register complete\"}";
request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
Console.WriteLine($"1# requestBody=`{requestBody}`");
Console.WriteLine($"2# request.Parameters.Count={request.Parameters.Count}");

Type parametersType = request.Parameters.GetType();  // Get the type of the request.Parameters object
PropertyInfo[] properties = parametersType.GetProperties();  // Get all the properties of the request.Parameters object
foreach (PropertyInfo property in properties)  // Iterate through the properties and print their details
{
    string propertyName = property.Name;
    object propertyValue = property.GetValue(request.Parameters);

    Console.WriteLine($"Property Name: {propertyName}");
    Console.WriteLine($"Property Value: {propertyValue}");
    Console.WriteLine();
}

foreach (var parameter in request.Parameters)
{
    Console.WriteLine($"3# .Name={parameter.Name}, .Value={parameter.Value}, .Type={parameter.Type}");
}

try
{
    string dash = new String('-', 80);
    var response = client.Execute(request);
    Console.WriteLine($"\n{dash}\nMethod=`{request.Method}`\nStatusCode={(int)response.StatusCode}\n4# response.Content=`{response.Content}`\n{dash}");
    var obj = JObject.Parse(response.Content);

    Console.WriteLine("Data_" + response.Content);
    //Console.ReadLine();
}
    catch (Exception ex) { 
    string ex1 = ex.ToString(); 
    Console.WriteLine($"Exception: {ex1}");
}
//$regbody = @{employee_id="00000371";code="00";message="register complete"}
//$reghdr = @{Authorization = "Basic UFNUUE46QywySllIbl9neTRSU0py"}
//Invoke-RestMethod -Uri "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/" -Method POST -Headers $reghdr -Body ($regbody|ConvertTo-Json)
//------------
//var request = new RestRequest("/users/{id}", Method.GET);
//request.AddUrlSegment("id", "123");
//var response = client.Execute(request);
//
//var request = new RestRequest("/users", Method.POST);
//request.AddJsonBody(new { name = "John", age = 30 });
//var response = client.Execute(request);
//-------------
//var client = new RestClient("https://api.example.com");  // Create a new RestClient instance
//var request = new RestRequest("users/{id}", Method.GET);  // Create a new RestRequest instance
//request.AddUrlSegment("id", "123"); // Add URL segment using AddUrlSegment() method
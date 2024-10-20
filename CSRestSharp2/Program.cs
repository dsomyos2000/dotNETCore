using System;
using RestSharp;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Reflection;

string HostURL = "http://10.81.1.44:8018";
string DataURL = "/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/";
string Authtoken = "UFNUUE46QywySllIbl9neTRSU0py";
var client = new RestSharp.RestClient($"{HostURL}{DataURL}");
var request = new RestSharp.RestRequest();
request.Method = RestSharp.Method.Post;

request.AddHeader("Authorization", "Basic " + Authtoken);
string requestBody = "{\"employee_id\": \"00000371\",\"code\": \"00\",\"message\": \"register complete\"}";
request.AddParameter("application/json", requestBody, ParameterType.RequestBody);

try
{
    var response = client.Execute(request);
    var obj = JObject.Parse(response.Content);

    Console.WriteLine("Data: " + response.Content);
    //Console.ReadLine();
}
    catch (Exception ex) { 
    string ex1 = ex.ToString(); 
    Console.WriteLine($"Exception: {ex1}");
}

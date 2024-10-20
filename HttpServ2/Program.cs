// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

class Program
{
    static async Task Main(string[] args)
    {
        const string PAYNEXT_UPDATEREGISTER = "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_UPDATEREGISTER.v1/";
        const string PAYNEXT_EMPPROFILE = "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_EMPPROFILE.v1/";
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Prefixes.Add("http://127.0.0.1:8080/");
        //listener.Prefixes.Add("http://+:8080/"); /*Require Administrator*/
        listener.Start();

        Console.WriteLine("Listening for requests...");
        var uri0 = new Uri(PAYNEXT_UPDATEREGISTER);
        var uri1 = new Uri(PAYNEXT_EMPPROFILE);
        const ulong maxNUM = 0xff00000AA;
        ulong gCnt = maxNUM;
        int nRound = 0;
        bool flagCont = true;
        while (listener.IsListening && flagCont)
        {
            if (gCnt > 0) { gCnt -= 1; } else { gCnt = maxNUM; nRound += 1; }
            try {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            //Console.WriteLine("ContentType='{0}'",request.ContentType);
            foreach (string headerName in request.Headers.AllKeys) {
                string headerValue = request.Headers[headerName];
                if (headerName == "Authorization" | headerName == "Content-Type") { 
                    Console.Write("✔️");
                    Console.Write("{0}: {1}", headerName, headerValue);
                }
            }
            Console.WriteLine("");
            string strURL = String.Format("{0}",request.Url);
            string strHost = strURL;
            string strApi = strURL;
            string strQry = strURL;
            string strRoute    = "/api/v1/update-status";
            int posOfapi        = strURL.IndexOf(strRoute);
            string empRoute = "/api/v1/employee-profile";
            int posOfemp      = strURL.IndexOf(empRoute);
            string responseString = "";
            if ( posOfapi > 0) {
                #region Update-Status
                using (System.IO.Stream body = request.InputStream) {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(body, request.ContentEncoding)) {
                        string requestBody = reader.ReadToEnd();
                        if (requestBody.Length >= 7) {
                            Console.Write("[{0}]", requestBody.Length);
                            Console.WriteLine(requestBody.Replace("\n", "").Replace("\r", "").Replace("  ", " "));
                            JObject jsonBody = JObject.Parse(requestBody);
                            JObject json = new JObject();
                            json.Add("employee_id", jsonBody["employee_id"]);
                            JObject jsonStat = (JObject)jsonBody["status"];
                            json.Add("code", jsonStat["code"]);
                            json.Add("message", jsonStat["message"]);
                            Console.WriteLine(json.ToString().Replace("\n", "").Replace("\r", "").Replace("  ", " "));

                            strApi = strURL.Substring(posOfapi, strURL.Length - posOfapi); 
                            strHost = strURL.Replace(strApi,"");
                            strQry = strURL.Replace(strHost+strRoute,"");
                            if (request.HttpMethod == "POST") {
                                using var client = new HttpClient();
                                var newRequestBody = json.ToString();
                                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py");
                                var psresponse = await client.PostAsync((uri0), new StringContent(newRequestBody));
                                var responseContent = await psresponse.Content.ReadAsStringAsync();
                                Console.WriteLine(responseContent);
                                if (responseContent.Length >= 7) {
                                    response.ContentType = "application/json";
                                    responseString = responseContent;
                                } else {
                                    response.ContentType = "application/json";
                                    responseString = "{\"code\": \"DATA_NOT_FOUND\",\"message\": \"User not found\",\"ref⁴\": "+gCnt+"; "+responseContent+",\"HttpMethod\": \""+request.HttpMethod+"\"}";
                                }
                            } else if (request.HttpMethod == "GET") {
                                responseString = "{\"code\": \"SUCCESS\",\"message\": \"Success\",\"ref⁵\": "+gCnt+"}";
                            } else {
                                response.ContentType = "text/plain";
                                responseString = String.Format("{0} - {1}; {2}; {3}; {4}({5})", request.HttpMethod, strHost, strRoute, strQry, gCnt, nRound);
                            }
                        } else {
                            if (request.HttpMethod == "GET") {
                                using var client = new HttpClient();
                                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py");
                                var content = new StringContent("{ \"message\":  \"register complete\", \"code\":  \"00\", \"employee_id\":  \"00000371\" }", System.Text.Encoding.UTF8, "application/json");
                                var psresponse = await client.PostAsync(uri0, content);
                                var responseContent = await psresponse.Content.ReadAsStringAsync();
                                Console.WriteLine(responseContent);
                                if (responseContent.Length >= 7) {
                                    responseString = responseContent;
                                    response.ContentType = "text/plain";
                                } else {
                                    responseString = String.Format("Lenght of response not JSON format! Response=[{0}]",responseContent);
                                    response.ContentType = "text/plain";
                                }
                            } else {
                                responseString = "{\"code\": \"DATA_NOT_FOUND\",\"message\": \"User not found\",\"ref⁶\": "+gCnt+",\"HttpMethod\": \""+request.HttpMethod+"\"}";
                                response.ContentType = "application/json";
                            }
                        }
                    }
                }
                #endregion Update-Status
            } else if (posOfemp > 0) {
                #region Employee-Profile
                using (System.IO.Stream body = request.InputStream) {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(body, request.ContentEncoding)) {
                        string requestBody = reader.ReadToEnd();
                        if (requestBody.Length >= 7) {
                            Console.Write("<{0}>", requestBody.Length);
                            Console.WriteLine(requestBody.Replace("\n", "").Replace("\r", "").Replace("  ", " "));
                            strApi = strURL.Substring(posOfemp, strURL.Length - posOfemp); 
                            strHost = strURL.Replace(strApi,"");
                            strQry = strURL.Replace(strHost+empRoute,"");
                            if (request.HttpMethod == "POST") {
                                using var client = new HttpClient();
                                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UFNUUE46QywySllIbl9neTRSU0py");
                                var psresponse = await client.PostAsync((uri1), new StringContent(requestBody));
                                var responseContent = await psresponse.Content.ReadAsStringAsync();
                                if (responseContent.Length >= 7) {
                                    responseString = responseContent;
                                    response.ContentType = "application/json";
                                } else {
                                    responseString = "{\"ref⁷\":"+gCnt+",\"code\": \"DATA_NOT_FOUND\",\"message\": \"Profile not found\"}";
                                    response.ContentType = "application/json";
                                }
                            }
                            else {
                                response.ContentType = "text/plain";
                                responseString = String.Format("{0} - {1}; {2}; {3}; {4}({5})", request.HttpMethod, strHost, empRoute, strQry, gCnt, nRound);
                            }
                        } else {
                            responseString = "{\"code\": \"DATA_NOT_FOUND\",\"message\": \"User not found\",\"ref⁸\": "+gCnt+",\"HttpMethod\": \""+request.HttpMethod+"\"}";
                            response.ContentType = "application/json";
                        }
                    }
                }
                #endregion Employee-Profile
            } else if (strURL.EndsWith("/end")) {
                responseString  = "End.";
                flagCont = false;
            }
            Console.WriteLine("Received request: {0} {1}", request.HttpMethod, strApi);

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
            } catch  (Exception e) {
                 Console.WriteLine(e.Message);
            }

        }
    }
}

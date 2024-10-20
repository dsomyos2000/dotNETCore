using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;

public class Program
{
    static UInt128 bigNum = UInt128.MaxValue;
    static UInt128 CountDown = bigNum;
    static UInt16 roundNum = 0;
    //Max:Min=1:8 for code 2XX
    //Max:Min=9:17 for code 3XX
    //Max:Min=1:42 for all code
    static RandomNumberGenerator random = new RandomNumberGenerator(1,8);
    static Dictionary<string, int> usedStatusCodes = new Dictionary<string, int>();
    static async Task Main(string[] args)
    {
        const string listenurl = "http://localhost:8087/";
        var listener = new HttpListener();
        listener.Prefixes.Add(listenurl); // Set the URL prefix to listen on

        listener.Start(); // Start the listener

        Console.WriteLine($"{listenurl}\nListening for requests...");

        while (true)
        {
            CountDown -= 1;
            if (CountDown <= 0) { CountDown = bigNum; roundNum += 1; }
            var context = await listener.GetContextAsync(); // Wait for an incoming request

            // Handle the request in a separate task
            Task.Run(() => HandleRequest(context));
        }
    }

    static void HandleRequest(HttpListenerContext context)
    {
        var request = context.Request;
        var response = context.Response;

        // Get the Authorization header from the request
        var authHeader = request.Headers["Authorization"];

        // Check if the Authorization header is present and starts with "Bearer "
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
        {
            // Extract the token from the Authorization header
            var token = authHeader.Substring("Bearer ".Length);

            // Validate the token or perform any necessary authentication/authorization logic
            // ...

            // Process the request and generate a response
            var responseData = $"Hello, World! Authorization=`{authHeader}`";
            foreach(KeyValuePair<string,int> data in usedStatusCodes) { responseData += $"\n[{ data.Value }] - { data.Key }"; }
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseData);

            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        } else if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic ")) {
            var retValue = System.Text.Encoding.UTF8.GetBytes($"Reuest with Authorization=`{authHeader}`");
            response.ContentLength64 = retValue.Length;
            response.OutputStream.Write(retValue, 0, retValue.Length);
            response.OutputStream.Close();
        } else {
            string[] statcodes = new string[] {
                "100 - Continue", //need to sent more response message.
                "101 - SwitchingProtocols",
                "200 - OK",
                "201 - Created",
                "202 - Accepted",
                "203 - NonAuthoritativeInformation",
                "204 - NoContent",
                "205 - ResetContent",
                "206 - PartialContent",
                "300 - MultipleChoices",
                "301 - MovedPermanently",
                "302 - Redirect",
                "303 - SeeOther",
                "304 - NotModified",
                "305 - UseProxy",
                "306 - Unused",
                "307 - TemporaryRedirect",
                "400 - BadRequest",
                "401 - Unauthorized",
                "402 - PaymentRequired",
                "403 - Forbidden",
                "404 - NotFound",
                "405 - MethodNotAllowed",
                "406 - NotAcceptable",
                "407 - ProxyAuthenticationRequired",
                "408 - RequestTimeout",
                "409 - Conflict",
                "410 - Gone",
                "411 - LengthRequired",
                "412 - PreconditionFailed",
                "413 - RequestEntityTooLarge",
                "414 - RequestUriTooLong",
                "415 - UnsupportedMediaType",
                "416 - RequestedRangeNotSatisfiable",
                "417 - ExpectationFailed",
                "426 - UpgradeRequired",
                "500 - InternalServerError",
                "501 - NotImplemented",
                "502 - BadGateway",
                "503 - ServiceUnavailable",
                "504 - GatewayTimeout",
                "505 - HttpVersionNotSupported",
                "999 - Not used."};
            //Random random = new Random();
            //int randomNumber = random.Next(1, 8); //0 to 41
            int randomNumber = random.GetUniqueRandomNumber();
            var strCode = statcodes[randomNumber].Substring(0,3);
            var numCode = int.Parse(strCode);
            // If the Authorization header is missing or does not start with "Bearer ",
            // return a 401 Unauthorized response
            //response.StatusCode = (int)HttpStatusCode.OK;
            //numCode = 100; Must be return other code again after return 100
            //numCode = 408;
            response.StatusCode = numCode;
            if ((numCode >= 200 && numCode <= 200) || (CountDown % 999 == 0)) {
                Console.WriteLine($"{randomNumber:D3}|{numCode} - `{strCode}`:{statcodes[randomNumber]}");
            }
            var skey = statcodes[randomNumber];
            if ( usedStatusCodes.ContainsKey(skey) ) { usedStatusCodes[skey] += 1; } else { usedStatusCodes.Add( skey, 1); }
            response.OutputStream.Close();
            //HttpStatusCode.Unauthorized   - (401) Unauthorized.
            //HttpStatusCode.OK             - 200
            //.NonAuthoritativeInformation  - 203 (ไม่ error ตอน request)
            //.BadRequest                   - 400
            //.Forbidden                    - (403) Forbidden.
            //.MethodNotAllowed             - (405) Method Not Allowed.
            //.NoContent                    - 204 (ไม่ error ตอน request)
            //.Found                        - (302) Redirect.
            //.UnsupportedMediaType         - (415) Unsupported Media Type.
        }
    }
    public class RandomNumberGenerator
    {
        private Random random;
        private List<int> previousNumbers;
        private int _mn;
        private int _mx;
        private int nxClear = 0;
        public RandomNumberGenerator(int mn, int mx)
        {
            random = new Random();
            previousNumbers = new List<int>();
            _mn = mn;
            _mx = mx;
            //Console.WriteLine($"min={_mn}, max={_mx}, Count={_mx - _mn + 1}");
        }
        public int GetUniqueRandomNumber()
        {
            //Console.WriteLine($".Count={previousNumbers.Count}");
            if (nxClear == 1) { 
                previousNumbers.Clear(); 
                nxClear = 0; 
                //Console.WriteLine($"--{bigNum - CountDown + 1}/{ roundNum }-----");
            }
            int randomNumber, countDown = (_mx - _mn);
            do {
                countDown -= 1;
                randomNumber = random.Next(_mn,_mx);
                //foreach(var x in previousNumbers) { Console.Write($"{x},");}
                //Console.WriteLine($"  => randomNumber={randomNumber}, countDown={countDown}");
                //if (previousNumbers.Count >= 6) { Console.WriteLine("Please any key to continue...");Console.ReadLine();Console.WriteLine(); }
            } while (previousNumbers.Contains(randomNumber) && countDown >= 0);
            previousNumbers.Add(randomNumber);
            if (previousNumbers.Count == (_mx - _mn)) { nxClear = 1; }
            return randomNumber;
        }
    }
}

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

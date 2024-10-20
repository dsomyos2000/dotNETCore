using Flurl.Http;
Console.WriteLine( await "http://10.81.1.44:8018/PSIGW/RESTListeningConnector/PSFT_HR/PAYNEXT_GETPROFILE.v1/?thai_id=696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e285533&employee_id=00000371".GetStringAsync() );

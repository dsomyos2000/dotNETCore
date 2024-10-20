void transactionalEmails_sendTemplate()

{

string URL = "http://api.inwise.com/rest/v1/transactional/emails/sendTemplate";

string api_key="XXXXXXXXXXX";

string DATA = @"{

"template_id":123456, // according to account's template

"message": {

"html": "

",

"text": "text  text",

"subject": "this is message from C# code",

"from_email": "YYY@inwise.com", // Sender email address according to the specific account

"from_name": "from me ",

"charset": "utf-8",

"content_type": "html",

"to": [

{

"email": "YYY@inwise.com",

"name": "YYY",

"type": "to" // Could be to/cc/bcc

}

]

}

}";



HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

request.Method = "POST";

request.ContentType = "application/json";

request.Accept = "application/json";

request.ContentLength = DATA.Length;

request.X-API-Key = api_key;

StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);

requestWriter.Write(DATA);

requestWriter.Close();



try

{

WebResponse webResponse = request.GetResponse();

Stream webStream = webResponse.GetResponseStream();

StreamReader responseReader = new StreamReader(webStream);

string response = responseReader.ReadToEnd();

Console.Out.WriteLine(response);

responseReader.Close();

Response.Write(response);

}

catch (Exception e1)

{

Console.Out.WriteLine("-----------------");

Console.Out.WriteLine(e1.Message);

Response.Write("asfd");

}

}
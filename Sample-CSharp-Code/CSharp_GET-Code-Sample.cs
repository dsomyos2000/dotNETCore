void contacts_getById()

{

string apikey = "API_KEY";

string contact_id = "CONTACT_ID";

string URL = "https://api.inwise.com/rest/v1/contacts/;

try

{

HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(URL);

myReq.Method = "GET";

myReq.ContentType = "application/json";

myReq.Accept = "application/json";

myReq.X-API-Key = apikey;

WebResponse myResponse = myReq.GetResponse();

Stream rebut = myResponse.GetResponseStream();

StreamReader readStream = new StreamReader(rebut, Encoding.UTF8);

string info = readStream.ReadToEnd();

myResponse.Close();

readStream.Close();



xxxx.InnerText = info;

//Response.Write(info);

}



catch (Exception e1)

{

Console.Out.WriteLine("-----------------");

Console.Out.WriteLine(e1.Message);

Response.Write(e1.ToString());

}

}
//##https://stackoverflow.com/questions/9034721/handling-multiple-requests-with-c-sharp-httplistener
private void CreateLListener()
{
    HttpListenerContext context = null;
    HttpListener listener = new HttpListener();
    bool listen = true;

    while(listen)
    {
        try
        {
            context = listener.GetContext();
        }
        catch (...)
        {
            listen = false;
        }
        // process request and make response
    }
}

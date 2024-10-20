// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class SslClient
{
    public static void Main()
    {
        TcpClient client = new TcpClient("localhost", 8800);
        SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
        try
        {
            sslStream.AuthenticateAsClient("localhost");
            byte[] message = Encoding.UTF8.GetBytes("Hello, server!");
            sslStream.Write(message);
            byte[] buffer = new byte[1024];
            int bytesRead = sslStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
        }
        catch (AuthenticationException e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
            if (e.InnerException != null)
            {
                Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
            }
        }
        finally
        {
            sslStream.Close();
            client.Close();
        }
    }

    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true;
        }
        Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
        return false;
    }
}

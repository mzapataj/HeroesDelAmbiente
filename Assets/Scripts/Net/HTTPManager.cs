using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

public class HTTPManager
{
    WebRequest request;
    WebResponse response;
    string hostname;

    public HTTPManager(string hostname)
    {
        this.hostname = hostname;
        //request.Credentials = CredentialCache.DefaultCredentials;

    }

    public void getMethod(string path = "")
    {
        request = WebRequest.Create(hostname + "/" + path);
        request.Method = "GET";
        response = request.GetResponse();
    }
   

    public void postMethod(string bodyJSON, string path = "")
    {
        request = WebRequest.Create(hostname + "/" + path);
        request.Method = "POST";
        request.ContentType = "application/json; charset=UTF-8";

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(bodyJSON);
        }

        response = request.GetResponse();

    }

    public string readResponse()
    {
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            return result;
        }
    }

}

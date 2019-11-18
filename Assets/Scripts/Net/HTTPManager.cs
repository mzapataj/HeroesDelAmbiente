using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPManager
{
    UnityWebRequest webRequest;
    WebRequest request;
    WebResponse response;
    string hostname;


    public HTTPManager(string hostname)
    {
        this.hostname = hostname;
        
        //loading = (Object.Instantiate(Resources.Load("Loading"), 
        //                        Vector3.zero, Quaternion.identity) as GameObject).transform.GetComponent<Loading>();
        //loading = Object.Instantiate(Resources.Load("Loading"), Vector2.zero, Quaternion.identity) as GameObject;
        //loading.transform.localScale = new Vector3(2, 2, 2);
        
        //loading.SetActive(false);

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

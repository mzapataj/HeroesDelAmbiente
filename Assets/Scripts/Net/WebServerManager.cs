using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebServerManager
{
    private GameObject waiting;

    public string hostname;
    

    public WebServerManager(string hostname = "https://quilla-cuidado-ambiental.herokuapp.com/api/v1")
    {
        this.hostname = hostname;
        waiting = UnityEngine.Object.Instantiate(Resources.Load("Waiting")) as GameObject;
        waiting.SetActive(false);
        waiting.transform.SetParent(GameObject.Find("Canvas").transform, false);
        waiting.transform.localPosition = Vector2.zero;
    }

    /*
    public void OnButtonGetScore()
    {
        waiting.SetActive(true);

        StartCoroutine(GetRequest("users ",result =>
        {
            Debug.Log(result);
            waiting.SetActive(false);
        }));
    }
    */
    public IEnumerator GetRequest(String path, Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(hostname+"/"+path);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            callback?.Invoke(request.downloadHandler.text);
        }
        //waiting.SetActive(false);
    }

    /*
    public void OnButtonSendScore()
    {      
        waiting.SetActive(true);
        StartCoroutine(PostRequest("users", "{\"user\":" +
            "{\"name\":\"" + scoreToSend.text + "\"," +
            "\"password\":\"GUEST\"}}", result =>
        {
            Debug.Log(result);
            waiting.SetActive(false);
        })); 
         
    }*/

    public IEnumerator PostRequest(string path, string jsonBody, Action<string> callback)
    {

        UnityWebRequest request = new UnityWebRequest(hostname+"/"+path, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
    
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
        }

        else
        {
            callback?.Invoke(request.downloadHandler.text);
        }
       
    }

}
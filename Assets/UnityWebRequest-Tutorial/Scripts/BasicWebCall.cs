using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BasicWebCall : MonoBehaviour
{
    private GameObject waiting;
    public Text messageText;
    public InputField scoreToSend;

    public string hostname = "https://quilla-cuidado-ambiental.herokuapp.com/api/v1";
    //readonly string getURL = "http://homecookedgames.com/tutorialScrips/UWR_Tut_Get.php";
    //readonly string postURL = "http://homecookedgames.com/tutorialScrips/UWR_Tut_Post.php";

    private void Start()
    {
        messageText.text = "Press buttons to interact with web server";

        waiting = Instantiate(Resources.Load("Waiting")) as GameObject;
        waiting.SetActive(false);
        waiting.transform.SetParent(GameObject.Find("Canvas").transform, false);
        waiting.transform.localPosition = Vector2.zero;
           
    }

    public void OnButtonGetScore()
    {
        messageText.text = "Downloading data...";
        waiting.SetActive(true);

        StartCoroutine(GetRequest(result =>
        {
            Debug.Log(result);
            waiting.SetActive(false);
        }));
        //StartCoroutine(SimpleGetRequest());
        //Debug.Log("Respuesta recibida.");
    }

    IEnumerator GetRequest(Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(hostname+"/"+"users");

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            messageText.text = request.downloadHandler.text;
            callback?.Invoke(request.downloadHandler.text);
        }
        //waiting.SetActive(false);
    }


    public void OnButtonSendScore()
    {
        if (scoreToSend.text == string.Empty)
        {
            messageText.text = "Error: No high score to send.\nEnter a value in the input field.";
        }
        else
        {
            messageText.text = "Sending data...";
            waiting.SetActive(true);
            StartCoroutine(PostRequest("users", "{\"user\":" +
                "{\"name\":\"" + scoreToSend.text + "\"," +
                "\"password\":\"GUEST\"}}", result =>
            {
                Debug.Log(result);
                waiting.SetActive(false);
            }));
            //StartCoroutine(SimplePostRequest(scoreToSend.text));
        }
    }

    IEnumerator PostRequest(string path, string jsonBody, Action<string> callback)
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
            messageText.text = request.downloadHandler.text;
            callback?.Invoke(request.downloadHandler.text);
        }
       
    }

}
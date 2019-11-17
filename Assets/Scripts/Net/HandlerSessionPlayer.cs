using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandlerSessionPlayer
{
    public GameObject popUpMenu;
    public GameObject waiting;
    public static HTTPManager httpManager;
    public static Dictionary<string, dynamic> currentUser_json;
    private string userSession;

    public string UserSession
    {
            get { return PlayerPrefs.GetString("userSession", ""); }
            set { PlayerPrefs.SetString("userSession", value); }
    }

    public HandlerSessionPlayer()
    {
        httpManager = new HTTPManager("https://quilla-cuidado-ambiental.herokuapp.com/api/v1");
        popUpMenu = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp").gameObject,"Panel");
        waiting = UnityEngine.Object
                    .Instantiate(Resources.Load("Waiting")) as GameObject;
        waiting.SetActive(false);
        waiting.transform.SetParent(popUpMenu.transform, false);
        //waiting.transform.parent = popUpMenu.transform;
        waiting.transform.localPosition = Vector2.zero;
        //currentUser_json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(UserSession);
        Debug.Log(currentUser_json);
        EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp").gameObject, "Button")
            .GetComponent<Button>().onClick.AddListener(NameInputButtonEvent);
        
        
    }

    public void NameInputButtonEvent()
    {
        string name = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp")
            .gameObject,"Panel").transform.Find("NameInput").GetComponent<InputField>().text;

        waiting.SetActive(true);

        if (!string.IsNullOrEmpty(name)) {
            //this.userSession = name;

            string jsonBody ="{\"user\":" +
                "{\"name\":\"" + name + "\"," +
                "\"password\":\"GUEST\"}}";



            httpManager.postMethod(jsonBody, "users");
            waiting.SetActive(false);

            currentUser_json = JsonConvert
                .DeserializeObject<Dictionary<string, dynamic>>(httpManager.readResponse());
            Debug.Log(currentUser_json["id"]);
            this.UserSession = currentUser_json.ToString();
            Debug.Log(currentUser_json);
            SceneManager.LoadScene("Games"); 
        }
    }
    
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandlerSessionPlayer
{
    public GameObject popUpMenu;
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

        //currentUser_json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(UserSession);
        Debug.Log(currentUser_json);
        EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp").gameObject, "Button")
            .GetComponent<Button>().onClick.AddListener(NameInputButtonEvent);
        
    }

    public void NameInputButtonEvent()
    {
        string name = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp")
            .gameObject,"Panel").transform.Find("NameInput").GetComponent<InputField>().text;


        if (!string.IsNullOrEmpty(name)) {
            //this.userSession = name;

            string jsonBody ="{\"user\":" +
                "{\"name\":\"" + name + "\"," +
                "\"password\":\"GUEST\"}}";


            httpManager.postMethod(jsonBody, "users");


            currentUser_json = JsonConvert
                .DeserializeObject<Dictionary<string, dynamic>>(httpManager.readResponse());
            Debug.Log(currentUser_json["id"]);
            this.UserSession = currentUser_json.ToString();
            Debug.Log(currentUser_json);
            SceneManager.LoadScene("Games"); 
        }
    }
    
}

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
    private string nameUser;

    public string NameUser
    {
            get { return PlayerPrefs.GetString("username",""); }
            set { PlayerPrefs.SetString("username", value); }
    }

    public HandlerSessionPlayer()
    {
        httpManager = new HTTPManager("https://quilla-cuidado-ambiental.herokuapp.com/api/v1");

        popUpMenu = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp").gameObject,"Panel");

        EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp").gameObject, "Button")
            .GetComponent<Button>().onClick.AddListener(NameInputButtonEvent);
        
    }

    public void NameInputButtonEvent()
    {
        string name = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp")
            .gameObject,"Panel").transform.Find("NameInput").GetComponent<InputField>().text;


        if (!string.IsNullOrEmpty(name)) {
            this.NameUser = name;

            string jsonBody ="{\"user\":" +
                "{\"name\":\"" + name + "\"," +
                "\"password\":\"GUEST\"}}";


            httpManager.postMethod(jsonBody, "users");


            currentUser_json = JsonConvert
                .DeserializeObject<Dictionary<string, dynamic>>(httpManager.readResponse());
            SceneManager.LoadScene("Games"); 
        }
    }
    
}

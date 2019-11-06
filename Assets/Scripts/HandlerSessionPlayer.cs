using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandlerSessionPlayer
{
    public GameObject popUpMenu;

    private string nameUser;
    public string NameUser
    {
            get { return PlayerPrefs.GetString("username",""); }
            set { PlayerPrefs.SetString("username", value); }
    }

    public HandlerSessionPlayer()
    { 
        popUpMenu = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp").gameObject,"Panel");

        EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp").gameObject, "Button")
            .GetComponent<Button>().onClick.AddListener(NameInputButtonEvent);
        
    }

    public void NameInputButtonEvent()
    {
        string name = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp")
            .gameObject,"Panel").transform.Find("NameInput").GetComponent<InputField>().text;
        

        if (!string.IsNullOrEmpty(name)){
            this.NameUser = name;
            SceneManager.LoadScene("Games"); 
        }
    }
    
}

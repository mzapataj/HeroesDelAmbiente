using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandlerSessionPlayer
{
    public Dictionary<string, dynamic> currentUser_json;
    private string userSession;

    public string UserSession
    {
            get { return PlayerPrefs.GetString("userSession", ""); }
            set { PlayerPrefs.SetString("userSession", value); }
    }

    public HandlerSessionPlayer()
    {
        if (!UserSession.Equals(""))
        {
            currentUser_json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(UserSession);
            Debug.Log(UserSession);
        }

        //currentUser_json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(UserSession);
        Debug.Log(currentUser_json);
    }
    
}

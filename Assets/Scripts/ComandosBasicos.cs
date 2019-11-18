﻿using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComandosBasicos : MonoBehaviour
{
    public static HandlerSessionPlayer handlerSessionPlayer = null;

    public GameObject panel;
    public InputField nameInput;
    public GameObject waiting;
    public static WebServerManager webServerManager;


    public void CargarEscena(string NombreDeEscena)
    {
        
        SceneManager.LoadSceneAsync(NombreDeEscena);

    }

    public void CargarEscenaGames()
    {

        if (handlerSessionPlayer == null)
        {
            handlerSessionPlayer = new HandlerSessionPlayer();
            webServerManager = new WebServerManager(); 
            panel.SetActive(true);
            /*waiting.SetActive(false);
            waiting.transform.SetParent(panel.transform, false);
            //waiting.transform.parent = popUpMenu.transform;
            waiting.transform.localPosition = Vector2.zero;
            */
        }
        /*
        if (handlerSessionPlayer.NameUser.Equals(""))
        {
            handlerSessionPlayer.popUpMenu.SetActive(true);
        }
        else
        {
            SceneManager.LoadSceneAsync("Games");
        }
        */
    }

    public void CreateNewGuestUser()
    {
        
        //string name = EmpadasNecesarias.FindObject(GameObject.Find("NewPlayerPopUp")
        //    .gameObject, "Panel").transform.Find("NameInput").GetComponent<InputField>().text;
        string name = nameInput.text;
        Debug.Log(name);
        waiting.SetActive(true);

        if (!string.IsNullOrEmpty(name))
        {
            //this.userSession = name;

            string jsonBody = "{\"user\":" +
                "{\"name\":\"" + name + "\"," +
                "\"password\":\"GUEST\"}}";


           StartCoroutine(webServerManager.PostRequest("users",jsonBody,
                result =>{
                    handlerSessionPlayer.currentUser_json = JsonConvert
                    .DeserializeObject<Dictionary<string, dynamic>>(result);
                    Debug.Log(handlerSessionPlayer.currentUser_json["id"]);
                    handlerSessionPlayer.UserSession = result;
                    Debug.Log(handlerSessionPlayer.currentUser_json);
                    waiting.SetActive(false);
                    SceneManager.LoadScene("Games");
                }
            ));


            
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComandosBasicos : MonoBehaviour
{
    HandlerSessionPlayer handlerSessionPlayer = null;


    public void CargarEscena(string NombreDeEscena)
    {
        
        SceneManager.LoadSceneAsync(NombreDeEscena);

    }

    public void CargarEscenaGames()
    {

        if (handlerSessionPlayer == null)
        {
            handlerSessionPlayer = new HandlerSessionPlayer();
            handlerSessionPlayer.popUpMenu.SetActive(true);
            Debug.Log("Pop up recien abierto");
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
}

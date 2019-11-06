using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComandosBasicos : MonoBehaviour
{
    public void CargarEscena(string NombreDeEscena)
    {
        
        SceneManager.LoadSceneAsync(NombreDeEscena);

    }

    public void CargarEscenaGames()
    {

        HandlerSessionPlayer handlerSessionPlayer = new HandlerSessionPlayer();

       

        if (handlerSessionPlayer.NameUser.Equals(""))
        {
            handlerSessionPlayer.popUpMenu.SetActive(true);
        }
        else
        {
            SceneManager.LoadSceneAsync("Games");
        }

    }
}

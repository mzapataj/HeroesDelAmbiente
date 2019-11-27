using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComandosBasicos : MonoBehaviour
{
    public static HandlerSessionPlayer handlerSessionPlayer = null;

    public GameObject panel;
    public GameObject pausaPanel;
    public InputField nameInput;
    public Button SubmitButton;
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
            /*waiting.transform.SetParent(panel.transform, false);
            //waiting.transform.parent = popUpMenu.transform;
            waiting.transform.localPosition = Vector2.zero;
            */
        }

        
        
        if (handlerSessionPlayer.currentUser_json == null)
        {
            panel.SetActive(true);
            waiting.SetActive(false);
        }
        else
        {
            SceneManager.LoadSceneAsync("Games");
        }
        
    }

    public void CreateNewGuestUser()
    {
        
        string name = nameInput.text;
        Debug.Log(name);

        SetDarkBackground(true);
        if (!string.IsNullOrEmpty(name))
        {

            string jsonBody = "{\"user\":" +
                "{\"name\":\"" + name + "\"," +
                "\"password\":\"GUEST\"}}";


           StartCoroutine(webServerManager.PostRequest("users",jsonBody,
                result => {
                    handlerSessionPlayer.currentUser_json = JsonConvert
                    .DeserializeObject<Dictionary<string, dynamic>>(result);
                    handlerSessionPlayer.UserSession = result;
                    SetDarkBackground(false);
                    SceneManager.LoadScene("Games");
                },
                error =>
                {
                    SceneManager.LoadScene("Games");
                }
            ));
        }
    }

    private void SetDarkBackground(bool active)
    {
        nameInput.GetComponent<InputField>().enabled = !active;
        SubmitButton.GetComponent<Button>().interactable = !active;
        waiting.SetActive(true);
        pausaPanel.SetActive(active);
       
    }


}

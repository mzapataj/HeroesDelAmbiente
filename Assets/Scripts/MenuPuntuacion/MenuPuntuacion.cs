using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPuntuacion : MonoBehaviour
{
    public GameObject pausaPanel;
    public GameObject RootPanel;
    public GameObject waiting;
    public Button ReciclajeButton;
    public Button AguaButton;
    public static WebServerManager webServerManager;
    public static List<Dictionary<string, dynamic>> usersBestScore;

    // Start is called before the first frame update
    void Start()
    {
        waiting.SetActive(false);
        pausaPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScoreSelection()
    {
        RootPanel.SetActive(true);
    }

    public void BestScoreReciclaje()
    {
        BestScore("1");
    }

    public void BestScoreAgua()
    {
        BestScore("2");
    }

    public void BestScore(string juego)
    {
        SetDarkBackground(true);
        webServerManager = new WebServerManager();
        StartCoroutine(webServerManager.GetRequest("scores?juego="+juego,
            result => {
                SetDarkBackground(false);

                usersBestScore = JsonConvert
                                 .DeserializeObject<List<Dictionary<string, dynamic>>>(result);
                /*
                foreach (Dictionary<string,dynamic> userBestScore in usersBestScore)
                {
                    Debug.Log(userBestScore["user_id"]);
                }*/
                
                //Debug.Log(result);
                SceneManager.LoadScene("BestScores");
                
            },
            error => {
                SceneManager.LoadScene("Menú");
            }
            ));
    }

    private void SetDarkBackground(bool active)
    {
        AguaButton.GetComponent<Button>().interactable = !active;
        ReciclajeButton.GetComponent<Button>().interactable = !active;
        waiting.SetActive(true);
        pausaPanel.SetActive(active);
    }



}

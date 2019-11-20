using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class Pause : MonoBehaviour
public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject waiting = null;
    public Sprite PauseImg;
    public Sprite ResumeImg;
    public static bool IsPaused = false;
    
    //[SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }


    public void PausaTrigger()
    {

        if (!IsPaused)
        {
            PauseGame();
            GameObject.Find("Pausa").GetComponent<Image>().sprite = ResumeImg;
        }
        else
        {
            ContinueGame();
            GameObject.Find("Pausa").GetComponent<Image>().sprite = PauseImg;
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0;   
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
        IsPaused = true;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        IsPaused = false;
        //enable the scripts again
    }

}
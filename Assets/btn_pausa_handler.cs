using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_pausa_handler : MonoBehaviour
{
    // Start is called before the first frame update

    public Pause pause;
    private bool is_paused;

    private void Start()
    {
        pause = new Pause();
        is_paused = false;
    }

    public void pausa_clicked()
    {
        
        if (!is_paused)
        {
            pause.PauseGame();
        }
        else
        {
            pause.ContinueGame();
        }

        is_paused = !is_paused;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mondy
{

    public int vida;
    public long puntaje = 0;
    public int tiempo;
    public Text vida_text; 

    public Mondy(int vida, Text vida_text){
        this.vida = vida;
        this.vida_text = vida_text;
    }
    
    public void perderVida()
    {
       
        vida -= 1;
        vida_text.text = "Vida x " + vida;
        
        if (vida <= 0)
        {
            Debug.Log("Juego terminado");
            GameObject.Find("Panel").GetComponent<Pause>().PauseGame();
        }

    }
    
}

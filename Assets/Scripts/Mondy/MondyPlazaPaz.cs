using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MondyPlazaPaz : Mondy
{

    public Dictionary<string, int> Desechos_depositados;
    
    public MondyPlazaPaz(int vida, Text vida_text) : base(vida, vida_text)
    {
        Desechos_depositados = new Dictionary<string, int>();
       
    }

    public override void perderVida()
    {
            vida -= 1;
            vida_text.text = "Vida x " + vida;

            if (vida <= 0)
            {
                Debug.Log("Juego terminado");
                GameObject.Find("Panel").GetComponent<Pause>().PauseGame();
            }

    }


    public void addBasura(string type)
    {
        try
        {
            Desechos_depositados[type] = Desechos_depositados[type] + 1;
        }
        catch (KeyNotFoundException)
        {
            Desechos_depositados.Add(type, 1);
        }
        
    }

    public override void setScore()
    {
        throw new System.NotImplementedException();  
        
    }
}

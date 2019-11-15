using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Mondy
{

    public int vida;
    public long puntaje = 0;
    //public int tiempo;
    public Text vida_text; 

    public Mondy(int vida, Text vida_text){
        this.vida = vida;
        this.vida_text = vida_text;
    }

    public abstract void perderVida();
    public abstract void setScore();
    public abstract void morir();

}

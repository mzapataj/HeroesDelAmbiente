using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Mondy
{
    public MonoBehaviour mbContext;
    public int vida;
    public long puntaje = 0;
    //public int tiempo;
    public Text vida_text;
    public Puntaje puntaje_text;

    public Mondy(int vida, Text vida_text, Puntaje puntaje_text, MonoBehaviour mbContext){
        this.vida = vida;
        this.vida_text = vida_text;
        this.puntaje_text = puntaje_text;
        this.mbContext = mbContext;
    }

    public abstract void perderVida();
    public abstract void setScore();
    public abstract void morir();

}

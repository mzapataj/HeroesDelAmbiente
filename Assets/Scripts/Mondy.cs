using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Mondy
{
    public MonoBehaviour mbContext;
    public int vida;
    public int puntaje = 0;
    //public int tiempo;
    public Puntaje puntaje_text;
    public Text vida_text;


    public Mondy(int vida, Puntaje puntaje_text, Text vida_text, MonoBehaviour mbContext){
        this.vida = vida;
        this.puntaje_text = puntaje_text;
        this.mbContext = mbContext;
        this.vida_text = vida_text;
        this.vida_text.text = "x " + vida; 
    }

    public abstract void PerderVida();
    public abstract void SetScore(long delta_lifetime);
    public abstract void Morir();

}

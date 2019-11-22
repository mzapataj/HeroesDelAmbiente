using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MondyVentanaMundo : Mondy
{
    public int GotasRecogidas;
    public MondyVentanaMundo(int vida, Text vida_text, Puntaje puntaje_text, MonoBehaviour mbContext) : base(vida, vida_text, puntaje_text, mbContext)
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void morir()
    {
        throw new System.NotImplementedException();
    }

    public override void perderVida()
    {
        throw new System.NotImplementedException();
    }

    public override void setScore()
    {
        throw new System.NotImplementedException();
    }
}

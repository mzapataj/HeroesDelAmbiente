using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    private int valor = 0;
    private Text valor_text;


    private void Start()
    {
        valor_text = gameObject.GetComponent<Text>();        
    }

    private void Update()
    {
        valor_text.text =  valor.ToString();
    }

    public void addValor(long delta_lifetime){

        if (3 > delta_lifetime){
            valor += 5;
        }
        else if(7 > delta_lifetime){
            valor += 3;  
        }
        else{
            valor += 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public int valor = 0;
    private Text valor_text;


    private void Start()
    {
        valor_text = gameObject.GetComponent<Text>();        
    }

    private void Update()
    {
        valor_text.text =  valor.ToString();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caneca : MonoBehaviour
{
    // Start is called before the first frame update

    
    private Desecho desecho = null;
    public string type = "ordinario"; 


    void Start()
    {
        Debug.Log("Caneca " + type + " creada.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Se activa al momento de detectar una colisión con otro gameObject con collider
     * 
     * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        //obtiene el desecho que colisionó con la caneca
        desecho = collision.gameObject.GetComponent<Desecho>();
       
    }

    /*Se activa cuando un gameObject con collider permanece en el area de colisión de la caneca
     * */
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D");
        if (desecho != null && desecho.isBeingHold == false)
        {
            if (desecho.type.Equals(type))
            {
                GenerarBasura.mondy.SetScore((int)desecho.Without_hold_seconds_elapsed);
                Debug.Log("¡Correcto!.");
                GenerarBasura.mondy.AddBasura(type);
                Debug.Log(GenerarBasura.mondy.Desechos_depositados[type]);
            }
            else
            {
                Debug.Log("Incorrecto.");
                GenerarBasura.mondy.PerderVida();
                
            }
            Destroy(desecho.gameObject);
            desecho = null;
        }
    }
    

}

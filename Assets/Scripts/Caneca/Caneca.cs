using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caneca : MonoBehaviour
{
    // Start is called before the first frame update

    private ObjectoController desecho = null;
    public string type = "ordinario"; 


    void Start()
    {
        Debug.Log("Caneca creada.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Caneca colisionada");
        desecho = collision.gameObject.GetComponent<ObjectoController>();
        Debug.Log("Tipo de desecho: "+desecho.type.ToString());

    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (desecho != null && desecho.isBeingHold == false)
        {
            if (desecho.type.Equals(type))
            {
                Debug.Log("¡Correcto!.");
            }
            else
            {
                Debug.Log("Incorrecto."); 
            }
            Destroy(desecho.gameObject);
            desecho = null;
        }
        
    }
    


}

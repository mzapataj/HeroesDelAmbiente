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
        //obtiene el desecho que colisionó con la caneca
        desecho = collision.gameObject.GetComponent<ObjectoController>();
        

    }

    /*Se activa cuando un gameObject con collider permanece en el area de colisión de la caneca
     * */
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

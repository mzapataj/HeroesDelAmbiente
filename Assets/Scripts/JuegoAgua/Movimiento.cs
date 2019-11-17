using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //public Transform player;
    public float speed = 5.0f;
    GameObject gota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mover(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")*0));
    }

    void mover(Vector2 direction)
    {
        this.transform.Translate(direction * speed * Time.deltaTime);
    }


    /*Se activa al momento de detectar una colisión con otro gameObject con collider
  * 
  * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //obtiene el desecho que colisionó con la caneca
        //desecho = collision.gameObject.GetComponent<ObjectoController>();
        gota = collision.gameObject;
        Destroy(gota);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {   
        
    }
}

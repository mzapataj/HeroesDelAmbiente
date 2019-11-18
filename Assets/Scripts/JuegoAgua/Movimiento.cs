using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //public Transform player;
    public float speed = 5.0f;
    GameObject gota;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mover(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")*0));
        /*if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if (Input.GetMouseButton(0))
        {
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }*/
    }
    /*private void FixedUpdate()
    {
        if (touchStart) {
            Vector2 offset = pointB;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            mover(direction * -1);
        }
    }*/

    void mover(Vector2 direction)
    {
        this.transform.Translate(direction * speed * Time.deltaTime);
    }


    /*Se activa al momento de detectar una colisión con otro gameObject con collider
  * 
  * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gota = collision.gameObject;
        Destroy(gota);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {   
        
    }
}

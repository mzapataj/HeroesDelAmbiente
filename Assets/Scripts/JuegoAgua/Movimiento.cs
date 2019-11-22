using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //public Transform player;
    public float speed = 10f;
    public float distance;
    public float offset_right;
    public float offset_left;
    private const float OFFSET_SIDE_MAP = 11; 
    GameObject gota;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 touchPosition = getPositionTouch();
        //mover(new Vector2(touchPosition.x, 0));
        //mover(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")*0));
        if (Input.GetMouseButton(0))
        {
            ControladorMovimiento();
        }
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


    private void ControladorMovimiento()
    {
        Vector2 touchPosition = getPositionTouch();
        Vector2 movPosition = touchPosition - (Vector2)this.transform.position;
        Debug.Log("touchPosition: " + touchPosition);
        Debug.Log("movPosition: "+movPosition);
        if (touchPosition.y < 4)
        {
            if (distance > 0)
            {
                if (!(movPosition.x <= distance && movPosition.x >= 0))
                {
                    Vector2 positionInicial = this.transform.position;
                    mover(new Vector2(movPosition.x, 0));

                }
            }
            else if (distance < 0)
            {
                if (!(movPosition.x >= distance && movPosition.x <= 0))
                {
                    mover(new Vector2(movPosition.x, 0));
                }
            }
        }
    }
    
    void mover(Vector2 direction)
    {
        //Vector2 positionInicial = this.transform.position;
        this.transform.Translate((direction) / (Mathf.Abs(direction.x)) * speed * Time.deltaTime);
        //this.transform.position = positionInicial;
        KeepInsideBounds();
    }

    private void KeepInsideBounds()
    {
        if (this.transform.position.x > 0)
        {
            if (this.transform.position.x > OFFSET_SIDE_MAP - offset_right)
            {
                this.transform.position = new Vector2(OFFSET_SIDE_MAP - offset_right, this.transform.position.y);
            }
        }
        else if (this.transform.position.x < -1*(OFFSET_SIDE_MAP - offset_left))
        {
            this.transform.position = new Vector2(-1 * (OFFSET_SIDE_MAP - offset_left), this.transform.position.y);
        }
    }


    /*Se activa al momento de detectar una colisión con otro gameObject con collider
  * 
  * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name.Equals("valde"))
        {
            gota = collision.gameObject;
            Destroy(gota);
        }

        if (gameObject.name.Equals("personajeconValde"))
        {
            gota = collision.gameObject;
            Destroy(gota);
        }
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private Vector3 getPositionTouch()
    {
        Vector2 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        return mousePos;
    }

}

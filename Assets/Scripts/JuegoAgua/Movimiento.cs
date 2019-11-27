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
    private float offset_side_map = 9.8f; 
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        offset_side_map = Lluvia.screenbounds.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !Lluvia.mondy.balde.WateringPlants)
        {
            ControladorMovimiento();
        }
     
    }


    private void ControladorMovimiento()
    {
        Vector2 touchPosition = getPositionTouch();
        Vector2 movPosition = touchPosition - (Vector2)this.transform.position;
        if (touchPosition.y < 4)
        {
            if (distance > 0)
            {
                if (!(movPosition.x <= distance && movPosition.x >= 0))
                {
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
        Vector3 antPosition = this.transform.position;
        this.transform.Translate((direction) / (Mathf.Abs(direction.x)) * speed * Time.deltaTime);
        KeepInsideBounds();
    }

    private void KeepInsideBounds()
    {
        if (this.transform.position.x > 0)
        {
            if (this.transform.position.x > offset_side_map - offset_right - Lluvia.planta.Width)
            {
                //this.transform.position = new Vector3(offset_side_map - offset_right - Lluvia.planta.Width
                //                        , this.transform.position.y, this.transform.position.z);
                PlantaCollision();
            }
        }
        else
         if (this.transform.position.x < -1*(offset_side_map - offset_left))
        {
            this.transform.position = new Vector3(-1 * (offset_side_map - offset_left)
                                        , this.transform.position.y, this.transform.position.z);

            

        }
    }
    
    /*Se activa al momento de detectar una colisión con otro gameObject con collider
  * 
  * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        switch (gameObject.name)
        {
            case "gotaagua(Clone)":
                GotaAguaCollision(gameObject);
                break;
            case "gotaacida(Clone)":
                AcidoCollision(gameObject); 
                break;
            case "planta":
    //            PlantaCollision();
                break;
            default:
                Debug.Log(gameObject.name);
                break;
        }
    }

    private void GotaAguaCollision(GameObject agua)
    {
        
        if (base.gameObject.name.Equals("valde"))
        {
            Debug.Log(agua.name);
            Lluvia.mondy.RecogerGota();
        }
        Destroy(agua);
    }
   
    private void AcidoCollision(GameObject acido)
    {
        Destroy(acido);
        if (gameObject.name.Equals("personajeconValde"))
        {
            Lluvia.mondy.PerderVida();
            
        }else if (gameObject.name.Equals("valde"))
        {
            Lluvia.mondy.balde.Vaciar(Balde.ArrojarHaciaIzq);
        }
        
    }

    private void PlantaCollision()
    {
        this.transform.position = new Vector3(offset_side_map - offset_right - Lluvia.planta.Width - 0.1f
                                       , this.transform.position.y, this.transform.position.z);
        Lluvia.mondy.RegarPlanta();
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

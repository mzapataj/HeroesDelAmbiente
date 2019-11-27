using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Desecho : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private float startPosX;
    private float startPosY;
    public string type;
    public bool isBeingHold = false;
    public float lifetime = 10f;
    public float Without_hold_seconds_elapsed;
    public int destroyTimeStoppedSeconds;
    public Image image;
    private const float ALPHA_RATIO = 0.08f, TRANSLUCID_TIME = 1.0f;

    void Awake()
    {
    }
    
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SetAlphaImage(ALPHA_RATIO));
        Without_hold_seconds_elapsed = 0;
    }


    // Update is called once per frame
    void Update()
    {


        if (isBeingHold == true)
        {
            Vector3 mousePos = GetPositionTouch();
            this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
        else
        {
            Without_hold_seconds_elapsed = Without_hold_seconds_elapsed + Time.deltaTime;
            /*
            if (Without_hold_seconds_elapsed >= lifetime)
            {
                Destroy(gameObject);
                GenerarBasura.mondy.PerderVida();
            }*/
        }
    }

   
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0) && !Pause.IsPaused)
        {

            Vector3 mousePos = GetPositionTouch();
            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;
            //startPosX = mousePos.x - this.transform.localPosition.x;
            //startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHold = true;

        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBeingHold = false;
    }
    /*
    private void OnMouseUp()
    {
        isBeingHold = false;

    }*/

    private Vector3 GetPositionTouch()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }

    private IEnumerator SetAlphaImage(float deltaAlpha) {

        while (true)
        {
            yield return new WaitForSeconds(TRANSLUCID_TIME);
            if (!isBeingHold) {
                image = GetComponent<Image>();
                var tempColor = image.color;

                if (tempColor.a  <= 0.3 )
                {
                    Destroy(gameObject);
                    //GenerarBasura.mondy.PerderVida();
                }
                else
                {
                    //tempColor.a = tempColor.a - deltaAlpha;
                    //tempColor.a = (tempColor.a*255 - deltaAlpha)/255;
                    tempColor.a -= deltaAlpha;
                    image.color = tempColor;
                }
                
            }
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject, lifetime);
    }
}

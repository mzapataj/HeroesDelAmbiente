﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectoController : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    public string type;
    public bool isBeingHold = false;
    private float lifetime = 10f;
    public int creation_time;


    void Awake()
    {
    }

    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject, lifetime);
        creation_time = DateTime.Now.Second;
    }


    // Update is called once per frame
    void Update()
    {

        if (isBeingHold == true)
        {
            Vector3 mousePos = getPosition();
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }

    }

    private void OnMouseDown()
    {
     
        if (Input.GetMouseButtonDown(0) && !Pause.IsPaused)
        {

            Vector3 mousePos = getPosition();

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHold = true;

        }

    }

    private void OnMouseUp()
    {
        isBeingHold = false;

    }

    private Vector3 getPosition()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        return mousePos;
    }
    

}

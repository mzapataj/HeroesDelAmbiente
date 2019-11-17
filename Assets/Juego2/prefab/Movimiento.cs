using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
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
        player.Translate(direction * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGotas : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGotas : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -screenBounds.y) //arreglar
        {
            Destroy(this.gameObject);
        }
    }
}

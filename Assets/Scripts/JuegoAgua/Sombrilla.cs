using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombrilla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.name.Equals("gotaagua(Clone)") ||
            gameObject.name.Equals("gotaacida(Clone)"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta : MonoBehaviour
{

    public Sprite[] StatesPlantImg = new Sprite[5];
    public Sprite[] StatesPlantDyingImg = new Sprite[4];
    public int GotasRecibidas, CurrentState;
    public float Width;
    public const int GotasParaCrecer = 5;
  
    // Start is called before the first frame update
    void Start()
    {
        GotasRecibidas = 0;
        CurrentState = 0;
        Width = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        Invoke("Secarse", 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    public void RecibirGotas(int gotas)
    {
        GotasRecibidas += gotas;
        CancelInvoke("Secarse");
        GameObject.Find("planta").GetComponent<SpriteRenderer>().sprite = StatesPlantImg[CurrentState];
        if (GotasRecibidas >= GotasParaCrecer) {
            Crecer();
        }
        Invoke("Secarse",10.0f);
    }

    private bool Crecer()
    {
        GotasRecibidas = 0;
        if (CurrentState < StatesPlantImg.Length) {
            CurrentState++;
            GameObject.Find("planta").GetComponent<SpriteRenderer>().sprite = StatesPlantImg[CurrentState];
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Secarse()
    {
        GameObject.Find("planta").GetComponent<SpriteRenderer>().sprite = StatesPlantDyingImg[CurrentState];
    }

}

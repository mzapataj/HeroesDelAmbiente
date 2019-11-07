using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerarBasura : MonoBehaviour
{

    public static MondyPlazaPaz mondy;
    public Tiempo tiempo;   
    public GameObject[] residuo;
    private Vector2 screenbounds;

    public float spawnTime = 1.0f;
    int i;
    public const float TOP_THRESHOLD = 1f, BOTTOM_THRESHOLD = 2f;
    
    // Start is called before the first frame update

    void Start()
    {
        
        mondy = new MondyPlazaPaz(5, GameObject.Find("Vida").GetComponent<Text>());
        tiempo = new Tiempo(GameObject.Find("Tiempo").GetComponent<Text>());    
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(OleadaBasura());
    }

    void Update()
    {
        tiempo.updateTime();

    }


    private void SpawnBasura()
    {
        i = Random.Range(0, 11); // Todas las basuras añadidas
 
        GameObject a = Instantiate(residuo[i]) as GameObject;
         
        a.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x),
            Random.Range(-BOTTOM_THRESHOLD, TOP_THRESHOLD));

    }
 
    // Update is called once per frame
    IEnumerator OleadaBasura()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnBasura();
        }
    }
}

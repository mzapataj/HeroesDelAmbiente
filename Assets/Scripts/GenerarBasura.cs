using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerarBasura : MonoBehaviour
{

    public static MondyPlazaPaz mondy;
    public GameObject[] residuo;
    public float spawnTime = 1.0f;
    private Vector2 screenbounds;
    int i;
    public const float bottom_threshold = 2f;
    public const float top_threshold = 1f;    
    // Start is called before the first frame update
    void Start()
    {
        
        mondy = new MondyPlazaPaz(5, GameObject.Find("Vida").GetComponent<Text>());
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(OleadaBasura());
    }

    private void SpawnBasura()
    {
        i = Random.Range(0, 11); // Todas las basuras añadidas
 
        GameObject a = Instantiate(residuo[i]) as GameObject;
         
        a.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x),
            Random.Range(-bottom_threshold, top_threshold));

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

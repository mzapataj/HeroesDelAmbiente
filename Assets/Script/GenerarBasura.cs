using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBasura : MonoBehaviour
{
    public GameObject[] residuo;
    public float spawnTime = 1.0f;
    private Vector2 screenbounds;
    int i; 
    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(OleadaBasura());
    }
    private void SpawnBasura()
    {
        i = Random.Range(0, 3); // arreglar al momento de añadir todas las basuras
 
        GameObject a = Instantiate(residuo[i]) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), Random.Range(-screenbounds.y, screenbounds.y));
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

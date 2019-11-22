using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lluvia : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Gota;
    public static MondyVentanaMundo mondy;
    public float respawnTime = 1.0f;
    int i;
    private Vector2 screenbounds;

    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //mondy = new MondyVentanaMundo();
        StartCoroutine(goteo());
    }
    private void spawnGota()
    {
        i = Random.Range(0, 10);
        GameObject a = Instantiate(Gota[i]) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), screenbounds.y * 1.1f);
    }
    IEnumerator goteo()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnGota();
        }
    }
    // Update is called once per frame
}

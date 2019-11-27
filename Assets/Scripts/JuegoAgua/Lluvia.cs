using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lluvia : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Gota;
    public static MondyVentanaMundo mondy;
    public static Planta planta;
    public static float gotaWidth = 1.1f;
    public float respawnTime = 1.0f;
    int i;
    public static Vector2 screenbounds;

    private void Awake()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    void Start()
    {
        mondy = new MondyVentanaMundo(3,
            GameObject.Find("Puntaje").gameObject.GetComponent<Puntaje>(),
            GameObject.Find("Vida").GetComponent<Text>(),
            GameObject.Find("Gotas").GetComponent<Text>(), this);

        planta = GameObject.Find("planta").GetComponent<Planta>();
        planta.Width = planta.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        StartCoroutine(goteo());
    }

    private void spawnGota()
    {
        i = Random.Range(0, 10);
        GameObject a = Instantiate(Gota[i]) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenbounds.x+2.5f,
                                            screenbounds.x- 4.5f - gotaWidth)
            , screenbounds.y * 1.1f);
    }

    IEnumerator goteo()
    {
        while (true)
        {
            spawnGota();
            yield return new WaitForSeconds(respawnTime);

        }
    }
    // Update is called once per frame
}

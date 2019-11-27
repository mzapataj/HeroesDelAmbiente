using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreAgua : MonoBehaviour
{

    public GameObject FilaTabla;
    public GameObject Content;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Dictionary<string, dynamic> userBestScore in MenuPuntuacion.usersBestScore)
        {

            GameObject row = Instantiate(FilaTabla) as GameObject;
            row.transform.SetParent(Content.transform, false);

            row.transform.GetChild(0).GetComponent<Text>().text = "" + userBestScore["user_id"];
            row.transform.GetChild(1).GetComponent<Text>().text = "" + userBestScore["name"];
            row.transform.GetChild(2).GetComponent<Text>().text = "" + userBestScore["gotas"];
            row.transform.GetChild(3).GetComponent<Text>().text = "" + userBestScore["value"];

        }
    }

        // Update is called once per frame
    void Update()
    {
        
    }
}

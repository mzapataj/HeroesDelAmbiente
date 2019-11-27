using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreReciclaje : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FilaTabla;
    public GameObject Content;
    void Start()
    {
        foreach (Dictionary<string,dynamic> userBestScore in MenuPuntuacion.usersBestScore)
        {

            GameObject row = Instantiate(FilaTabla) as GameObject;
            row.transform.SetParent(Content.transform,false);
            Debug.Log(userBestScore.ToString());
            
            
            
            
            row.transform.GetChild(0).GetComponent<Text>().text = ""+userBestScore["user_id"];
            row.transform.GetChild(1).GetComponent<Text>().text = ""+userBestScore["name"];
            row.transform.GetChild(2).GetComponent<Text>().text = ""+userBestScore["ordinario"];
            row.transform.GetChild(3).GetComponent<Text>().text = ""+userBestScore["peligroso"];
            row.transform.GetChild(4).GetComponent<Text>().text = ""+userBestScore["papel"];
            row.transform.GetChild(5).GetComponent<Text>().text = ""+userBestScore["plastico"];
            row.transform.GetChild(6).GetComponent<Text>().text = ""+userBestScore["bombillo"];
            row.transform.GetChild(7).GetComponent<Text>().text = ""+userBestScore["pila"];
            row.transform.GetChild(8).GetComponent<Text>().text = ""+userBestScore["value"];
            
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

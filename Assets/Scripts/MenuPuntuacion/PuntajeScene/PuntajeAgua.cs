using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuntajeAgua : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Puntaje").GetComponent<Text>().text = Lluvia.mondy.puntaje.ToString();
        GameObject.Find("Gotas").GetComponent<Text>().text = Lluvia.mondy.balde.GotasNormalesRecogidas.ToString();
        GameObject.Find("btnRegresar").GetComponent<Button>().onClick.AddListener(ReturnToHome);
    }

    private void ReturnToHome()
    {
        SceneManager.LoadScene("Menú");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuntajeReciclaje : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("puntaje").GetComponent<Text>().text = GenerarBasura.mondy.puntaje_text.valor.ToString();
        GameObject.Find("ordinarioText").GetComponent<Text>().text = "X "+GenerarBasura.mondy.
                                                                        Desechos_depositados["ordinario"];
        GameObject.Find("peligrosoText").GetComponent<Text>().text = "X "+ GenerarBasura.mondy.
                                                                    Desechos_depositados["peligroso"];
        GameObject.Find("papelText").GetComponent<Text>().text = "X "+ GenerarBasura.mondy.
                                                                    Desechos_depositados["papel"];
        GameObject.Find("plasticoText").GetComponent<Text>().text = "X "+ GenerarBasura.mondy.
                                                                    Desechos_depositados["plastico"];
        GameObject.Find("bombilloText").GetComponent<Text>().text = "X "+GenerarBasura.mondy.
                                                                    Desechos_depositados["bombillo"];
        GameObject.Find("pilaText").GetComponent<Text>().text = "X "+ GenerarBasura.mondy.
                                                                    Desechos_depositados["pila"];
        GameObject.Find("btnRegresar").GetComponent<Button>().onClick.AddListener(returnToHome);
    }

    private void returnToHome()
    {
        SceneManager.LoadScene("Menú");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

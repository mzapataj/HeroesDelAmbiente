using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MondyPlazaPaz : Mondy
{

    public Dictionary<string, int> Desechos_depositados;
    
    
    public MondyPlazaPaz(int vida, Text vida_text, Puntaje puntaje_text, MonoBehaviour mbContext) 
                        : base(vida, vida_text, puntaje_text, mbContext)
    {
        Desechos_depositados = new Dictionary<string, int>();
        Desechos_depositados.Add("ordinario", 0);
        Desechos_depositados.Add("peligroso", 0);
        Desechos_depositados.Add("papel", 0);
        Desechos_depositados.Add("plastico", 0);
        Desechos_depositados.Add("bombillo", 0);
        Desechos_depositados.Add("pila", 0);
    }

    public override void perderVida()
    {
            vida -= 1;
            vida_text.text = "Vida x " + vida;

            if (vida <= 0)
            {
                morir();    
            }

    }

    public override void morir()
    {
        Pause pause = new Pause();
        Debug.Log("Juego terminado");
        WebServerManager webServerManager = new WebServerManager();

        Dictionary<string, dynamic> jsonBody_dictionary = new Dictionary<string, dynamic>();
        Desechos_depositados.Add("value", puntaje_text.valor);
        jsonBody_dictionary.Add("score",Desechos_depositados);
        string jsonBody = JsonConvert.SerializeObject(jsonBody_dictionary);
        Debug.Log("Json body: " +jsonBody);
        pause.PauseGame();

        if (ComandosBasicos.handlerSessionPlayer == null)
        {
            mbContext.StartCoroutine(webServerManager.PostRequest("users/39/scores",
            //mbContext.StartCoroutine(webServerManager.PostRequest("users/"+(string)ComandosBasicos.handlerSessionPlayer.currentUser_json["id"] + "/scores",
            jsonBody, result =>
            {
                pause.ContinueGame();
                SceneManager.LoadScene("ScoreFinalReciclaje");

            }));

        }
        else
        {
            string id_current_user = ""+ComandosBasicos.handlerSessionPlayer.currentUser_json["id"];
            mbContext.StartCoroutine(webServerManager.PostRequest("users/"+id_current_user + "/scores",
                jsonBody, result =>
                {
                    pause.ContinueGame();
                    SceneManager.LoadScene("ScoreFinalReciclaje");

                }));
            //HandlerSessionPlayer.httpManager.postMethod(,
            //    "users/"+HandlerSessionPlayer.currentUser_json["id"]+"/scores");
        }
    }

    public void addBasura(string type)
    {
        try
        {
            Desechos_depositados[type] = Desechos_depositados[type] + 1;
        }
        catch (KeyNotFoundException)
        {
            Desechos_depositados.Add(type, 1);
        }
        
    }
 

    public override void setScore()
    {
        throw new System.NotImplementedException();  
        
    }
}

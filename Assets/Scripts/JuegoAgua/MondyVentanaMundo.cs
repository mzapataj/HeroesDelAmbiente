using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MondyVentanaMundo : Mondy
{
    public Balde balde;
    public Text gotas_recogidas_text;

    public MondyVentanaMundo(int vida, Puntaje puntaje_text, Text vida_text , Text gotas_text, MonoBehaviour mbContext) 
    : base(vida, puntaje_text, vida_text, mbContext)
    {
        balde = GameObject.Find("valde").GetComponent<Balde>();
        gotas_recogidas_text = gotas_text;
    }


    public void RecogerGota() {
        
        if (!balde.IsFull())
        {
            balde.GotasNormalBalde++;
            balde.GotasNormalesRecogidas++;
            gotas_recogidas_text.text = "x " + balde.GotasNormalesRecogidas;
            Debug.Log("Tiene " + balde.GotasNormalBalde + " gotas normales.");
                
        }

        balde.SetSprite();

    }

    public void RegarPlanta()
    {
        int gotas = balde.GotasNormalBalde;
        if (gotas > 0)
        {
            SetScore(0);
            balde.Vaciar(Balde.ArrojarHaciaDer);
            Lluvia.planta.RecibirGotas(gotas);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Morir()
    {
        Pause pause = GameObject.Find("Canvas").GetComponent<Pause>();
        pause.PauseGame();
        pause.waiting.SetActive(true);

        WebServerManager webServerManager = new WebServerManager();
        Dictionary<string, dynamic> jsonBody_dictionary = new Dictionary<string, dynamic>();
        Dictionary<string, dynamic> jsonBodyRoot_dictionary = new Dictionary<string, dynamic>();

        jsonBody_dictionary.Add("value", puntaje);
        jsonBody_dictionary.Add("gotas", balde.GotasNormalesRecogidas);
        jsonBodyRoot_dictionary.Add("water_score", jsonBody_dictionary);

        string jsonBody = JsonConvert.SerializeObject(jsonBodyRoot_dictionary);
        string id_current_user = "" + ComandosBasicos.handlerSessionPlayer.currentUser_json["id"];
        mbContext.StartCoroutine(webServerManager.PostRequest("users/" + id_current_user+"/water_score",jsonBody, 
            result => {
                SceneManager.LoadSceneAsync("ScoreFinalAgua");
            },
            error => {
                SceneManager.LoadScene("ScoreFinalAgua");
            }));
        
    }

    public override void PerderVida()
    {
        vida-=1;
        vida_text.text = "x " + vida; 
        
        if(vida <= 0)
        {
            Morir();
        }
    }
 

    public override void SetScore(long delta_lifetime)
    {

        switch (balde.GotasNormalBalde)
        {
            case 1:
                puntaje += 2;
                break;
            case 2:

                puntaje += 5;
                break;
            case 3:
                puntaje += 9;
                break;
        }

        puntaje_text.valor = puntaje;
        
    }
}

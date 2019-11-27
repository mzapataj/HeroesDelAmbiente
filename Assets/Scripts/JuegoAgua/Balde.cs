using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balde : MonoBehaviour
{
    public Sprite Vacio;
    public Sprite LLeno;
    public Sprite DerramandoAgua;
    public Sprite DerramandoAcido;
    public GameObject GotaAgua;
    public GameObject GotaAcida;
    //public GameObject objectToRotate;
    public bool WateringPlants;

    public int GotasNormalesRecogidas;
    public int capacidad = 3;
    public int GotasNormalBalde;
    public const int ArrojarHaciaDer = -1;
    public const int ArrojarHaciaIzq =  1;

    private void Start()
    {
        capacidad = 3;
    }
    public bool IsFull()
    {
        return (GotasNormalBalde >= capacidad);
        
    }

    public void SetSprite()
    {
        if (IsFull())
        {
            GameObject.Find("valde").GetComponent<SpriteRenderer>().sprite = LLeno;
            Debug.Log("Valde lleno");
        }
        else
        {
            GameObject.Find("valde").GetComponent<SpriteRenderer>().sprite = Vacio;
        }
    }


    public void Vaciar(float sentido)
    {
        int tempGotasAgua = GotasNormalBalde;
        GotasNormalBalde = 0;
        StartRotationReturningPosition(new Vector3(0,0,sentido*90), 1, tempGotasAgua);   
    }

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        WateringPlants = true;
        Quaternion startRotation = gameObject.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            gameObject.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        gameObject.transform.rotation = endRotation;
        WateringPlants = false;
    }

    public void StartRotation(Vector3 angles)
    {
        if (!WateringPlants)
            StartCoroutine(Rotate(angles, 1));
    }

    private IEnumerator RotateReturnPosition(Vector3 angles, float duration, int gotasAgua)
    {
        WateringPlants = true;
        Quaternion startRotation = gameObject.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        float semiduration = duration/2;

        for (float t = 0; t < semiduration; t += Time.deltaTime)
        {
            gameObject.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / semiduration);
            yield return null;
        }

        GameObject a;
        if (angles.z < 0)
        {
            a = Instantiate(GotaAgua) as GameObject;
            a.GetComponent<MovGotas>().GetRigidbody().AddForce(new Vector2(200, 0), ForceMode2D.Force);
            a.transform.position = (Vector2)transform.position + new Vector2(1f, -0.3f);
        }
        else
        {
            a = Instantiate(GotaAcida) as GameObject;
            a.GetComponent<MovGotas>().GetRigidbody().AddForce(new Vector2(-200, 0), ForceMode2D.Force);
            a.transform.position = (Vector2)transform.position + new Vector2(-1f, -0.3f);
        }

        SetSprite();
        for (float t = 0; t < semiduration; t += Time.deltaTime)
        {
            gameObject.transform.rotation = Quaternion.Lerp(endRotation, startRotation, t / semiduration);
            yield return null;
        }
        gameObject.transform.rotation = startRotation;


        WateringPlants = false;

    }

    public void StartRotationReturningPosition(Vector3 angles, float duration, int gotasAgua)
    {
        if (!WateringPlants)
            StartCoroutine(RotateReturnPosition(angles, duration, gotasAgua));
    }

}

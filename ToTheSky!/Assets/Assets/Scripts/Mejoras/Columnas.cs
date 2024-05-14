using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Columnas : MonoBehaviour
{
    Puntuacion_Mejora puntuacionMejoraScript;

    private void Start()
    {
        puntuacionMejoraScript = GameObject.Find("Puntuacion").GetComponent<Puntuacion_Mejora>();
    }
    void ActivarLasColumnas()
    {
        if (puntuacionMejoraScript.puntuacion>=30)
        {

        }
    }

}

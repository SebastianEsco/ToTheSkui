using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Columnas : MonoBehaviour
{
    Puntuacion_Mejora puntuacionMejoraScript;

    public delegate void ActivarColumnasDelegate();
    public static event ActivarColumnasDelegate OnActivarColumnas;

    private void Start()
    {
        puntuacionMejoraScript = GameObject.Find("Puntuacion").GetComponent<Puntuacion_Mejora>();
        
    }
    public void ActivarLasColumnas()
    {
        if (puntuacionMejoraScript.puntuacion >= 30)
        {
            puntuacionMejoraScript.puntuacion -= 30;

            Debug.Log(" se compro mejora, puntuacion:" + puntuacionMejoraScript.puntuacion);
            //OnActivarColumnas?.Invoke();
        }
    }

}

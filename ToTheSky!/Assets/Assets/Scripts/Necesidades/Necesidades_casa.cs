using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necesidades_casa : MonoBehaviour
{
    //private void Start()
    //{
    //    Debug.Log("se detecta collider");
    //}


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colision activa");

        if (other.CompareTag("Edificio"))
        {
            Debug.Log("colision activa");
            // Obtener el nombre del objeto
            string nombreObjeto = other.gameObject.name;

            // Llamar a funciones basadas en el nombre del objeto
            if (nombreObjeto == "Casita")
            {
                HacerAlgoParaCasa();
            }
            if (nombreObjeto == "Energia")
            {
                HacerAlgoParaEnergia();
            }
            if (nombreObjeto == "lava")
            {
                HacerAlgoParaLava();
            }
            if (nombreObjeto == "Iglesia")
            {
                HacerAlgoParaIglesia();
            }
        }
    }

    private void HacerAlgoParaCasa()
    {
        Debug.Log("Haciendo algo para la casa...");
        // Coloca aqu� el c�digo para manejar la casa
    }

    private void HacerAlgoParaEnergia()
    {
        Debug.Log("Haciendo algo para la energ�a...");
        // Coloca aqu� el c�digo para manejar la energ�a
    }

    private void HacerAlgoParaLava()
    {
        Debug.Log("Haciendo algo para la lava...");
        // Coloca aqu� el c�digo para manejar la lava
    }

    private void HacerAlgoParaIglesia()
    {
        Debug.Log("Haciendo algo para la iglesia...");
        // Coloca aqu� el c�digo para manejar la iglesia
    }
}

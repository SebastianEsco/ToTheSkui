using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarDistancia : MonoBehaviour
{
    Necesidades_casa necesidades;
    float rango;

    private void Update()
    {
        if (GameObject.Find("Casita(Clone)"))
        {
            necesidades = GameObject.Find("Casita(Clone)").GetComponent<Necesidades_casa>();
            rango = necesidades.distanciaAElectricidad;
        }
        else if (GameObject.Find("Iglesia(Clone)"))
        {
            necesidades = GameObject.Find("Iglesia(Clone)").GetComponent<Necesidades_casa>();
            rango = necesidades.distanciaAElectricidad;
        }
        else
        {
            rango = 3;
        }


        transform.localScale = Vector3.one * rango;
    }
}

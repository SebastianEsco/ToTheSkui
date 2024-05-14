using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Columnas : MonoBehaviour
{

    public TextMeshProUGUI textoPrecio, textoNivel;
    Puntuacion_Mejora puntuacionMejoraScript;
    DatosDeMejoras datosDeMejoras;
    public int precio;
    public int nivelDeLaMejora;

    public bool columna, estabilidad, bases;
    private void Start()
    {
        puntuacionMejoraScript = GameObject.Find("Puntuacion").GetComponent<Puntuacion_Mejora>();
        datosDeMejoras = GameObject.Find("Puntuacion").GetComponent<DatosDeMejoras>();
        
        if(columna)
        {
            precio = datosDeMejoras.precioMejoraColumna;
            nivelDeLaMejora = datosDeMejoras.nivelMejoraColumna;
        }
        else if(estabilidad)
        {
            precio = datosDeMejoras.precioMejoraEstabilidad;
            nivelDeLaMejora = datosDeMejoras.nivelMejoraEstabilidad;
        }
        else
        {
            precio = datosDeMejoras.precioMejoraBases;
            nivelDeLaMejora = datosDeMejoras.nivelMejoraBases;
        }

    }
    private void Update()
    {
        textoNivel.text = "Nivel " + nivelDeLaMejora.ToString();
        textoPrecio.text = "Precio: " + precio.ToString();
    }
    public void ActivarLasColumnas()
    {
        if (puntuacionMejoraScript.puntuacion >= precio)
        {
            puntuacionMejoraScript.puntuacion -= precio;
            nivelDeLaMejora++;
            precio += precio * (nivelDeLaMejora+1);
            datosDeMejoras.nivelMejoraColumna = nivelDeLaMejora;
            datosDeMejoras.precioMejoraColumna = precio;

        }
    }

    public void OnMejoraEstabilidad()
    {
        if (puntuacionMejoraScript.puntuacion >= precio)
        {
            puntuacionMejoraScript.puntuacion -= precio;
            nivelDeLaMejora++;
            precio += precio * (nivelDeLaMejora + 1);
            datosDeMejoras.nivelMejoraEstabilidad = nivelDeLaMejora;
            datosDeMejoras.precioMejoraEstabilidad = precio;

        }
    }

    public void OnMejoraBases()
    {
        if (puntuacionMejoraScript.puntuacion >= precio)
        {
            puntuacionMejoraScript.puntuacion -= precio;
            nivelDeLaMejora++;
            precio += precio * (nivelDeLaMejora + 1);
            datosDeMejoras.nivelMejoraBases = nivelDeLaMejora;
            datosDeMejoras.precioMejoraBases = precio;

        }
    }

}

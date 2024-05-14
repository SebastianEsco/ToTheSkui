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
    int guardarPrecioMomentaneo;
    public int nivelDeLaMejora;

    private void Start()
    {
        puntuacionMejoraScript = GameObject.Find("Puntuacion").GetComponent<Puntuacion_Mejora>();
        datosDeMejoras = GameObject.Find("Puntuacion").GetComponent<DatosDeMejoras>();
        guardarPrecioMomentaneo = precio;
        nivelDeLaMejora = datosDeMejoras.nivelMejoraColumna;

        for (int i = 0; i < nivelDeLaMejora-1; i++) //ARREGLAR ESTO
        {
            precio += precio * (nivelDeLaMejora + 1);
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

        }
    }

    public void OnMejoraEstabilidad()
    {
        if (puntuacionMejoraScript.puntuacion >= precio)
        {
            puntuacionMejoraScript.puntuacion -= precio;
            nivelDeLaMejora++;
            precio += precio * 2;
            datosDeMejoras.NivelMejoraEstabilidad = nivelDeLaMejora;
        }
    }

}

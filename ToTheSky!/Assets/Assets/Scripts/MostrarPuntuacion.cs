using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MostrarPuntuacion : MonoBehaviour
{
    Puntuacion_Mejora puntuacion;
    public TextMeshProUGUI texto;
    void Start()
    {
        puntuacion = GameObject.Find("Puntuacion").GetComponent<Puntuacion_Mejora>();
    }

    void Update()
    {
        texto.text = "Puntuacion: " + puntuacion.puntuacion;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion_Mejora : MonoBehaviour
{

    public int puntuacion;

    public TextMeshProUGUI textoPuntuacion;

    // Start is called before the first frame update
    public void aumentarPuntuacion()
    {
        puntuacion = puntuacion + 20;
        textoPuntuacion.text = "Puntuacion: " + puntuacion;

    }

    //public int core.puntuacion;

    // Update is called once per frame
    void Update()
    {
        
    }
}

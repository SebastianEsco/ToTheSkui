using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion_Mejora : MonoBehaviour
{

    public int puntuacion;
    static Puntuacion_Mejora instance;

    private void Awake()
    {
        // Si ya hay una instancia creada, destruye esta
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Si no hay una instancia, esta es la instancia única
        instance = this;

        // Asegura que este objeto no se destruya entre escenas
        DontDestroyOnLoad(gameObject);
    }



    public void AumentarPuntuacion(int cantidad)
    {
        puntuacion += cantidad;
        

    }
}

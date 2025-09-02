using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion_Mejora : MonoBehaviour
{

    public int puntuacion;
    public int score;
    static Puntuacion_Mejora instance;
    AuthHandler auth;

    private void Awake()
    {
        auth = GetComponent<AuthHandler>();
        // Si ya hay una instancia creada, destruye esta
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Si no hay una instancia, esta es la instancia �nica
        instance = this;

        // Asegura que este objeto no se destruya entre escenas
        DontDestroyOnLoad(gameObject);
    }

    public void ReiniciarScore()
    {
        auth.UpdateScore(score);
        Debug.Log("Puntaje actualizado");
        score = 0;
    }



    public void AumentarPuntuacion(int cantidad)
    {
        puntuacion += cantidad;
        score += cantidad;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones_Menu : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public int escenaACambiar;

    // Método que se ejecutará al hacer clic en el botón
    public void CambiarEscena()
    {
        // Cargar la escena especificada
        SceneManager.LoadScene(escenaACambiar); //indice de escena a cambiar
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlarCamara : MonoBehaviour
{
    public float velocidadDeScroll;

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Calcular el desplazamiento en el eje Y de la c�mara
        float desplazamientoY = scroll * velocidadDeScroll * Time.deltaTime;

        // Mover la c�mara en el eje Y
        transform.Translate(0, desplazamientoY, 0);
    }
}

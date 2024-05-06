using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlarCamara : MonoBehaviour
{
    public float velocidadDeScroll;
    MedidorDeAltura medidor;

    private void Start()
    {
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
    }
    void Update()
    {
        if(transform.position.y > 1 && transform.position.y < medidor.altura + 10)
        {
            
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Calcular el desplazamiento en el eje Y de la cámara
        float desplazamientoY = scroll * velocidadDeScroll * Time.deltaTime;


        if(transform.position.y < 1 && scroll<0)
        {
            desplazamientoY = 0;
        }

        if(transform.position.y > medidor.altura + 10 && scroll > 0)
        {
            desplazamientoY = 0;
        }

        // Mover la cámara en el eje Y
        transform.Translate(0, desplazamientoY, 0);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlarCamara : MonoBehaviour
{
    public float velocidadDeScroll;
    MedidorDeAltura medidor;
    Tutorial tutorial;

    private void Start()
    {
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        if(GameObject.Find("TUTORIAL") != null)
        {
            tutorial = GameObject.Find("TUTORIAL").GetComponent <Tutorial>();
        }
    }
    void Update()
    {

        if(GameObject.Find("TUTORIAL") != null)
        {
            if (!tutorial.tutorialActivo)
            {
                HacerScroll();
            }
            
        }
        else
        {
            HacerScroll();
        }


    }

    public void HacerScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Calcular el desplazamiento en el eje Y de la cámara
        float desplazamientoY = scroll * velocidadDeScroll * Time.deltaTime;


        if (transform.position.y < 1 && scroll < 0)
        {
            desplazamientoY = 0;
        }

        if (transform.position.y > medidor.altura + 10 && scroll > 0)
        {
            desplazamientoY = 0;
        }

        // Mover la cámara en el eje Y
        transform.Translate(0, desplazamientoY, 0);
    }
}

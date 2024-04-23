using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerEdificio : MonoBehaviour
{
    public GameObject[] edificios;
    MedidorDeAltura medidor;
    int edificioAPoner;

    private void Start()
    {
        edificioAPoner = 0;
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 posicionDelClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(posicionDelClic.y > -2 )
            {
                Instantiate(edificios[edificioAPoner], posicionDelClic, Quaternion.identity);
                medidor.MedirEdificios();
            }

        }
    }

    public void EdificoElegido(int edificioElegido)
    {
        edificioAPoner = edificioElegido;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerEdificio : MonoBehaviour
{
    public GameObject[] edificios;
    MedidorDeAltura medidor;
    int edificioAPoner;

    Core core;

    private void Start()
    {
        edificioAPoner = 0;
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        core = GameObject.Find("Core").GetComponent<Core>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

            Vector2 posicionDelClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(posicionDelClic.y > -2  && core.RevisarCuantoFaltaPorPoner(edificioAPoner) > 0)
            {
                Instantiate(edificios[edificioAPoner], posicionDelClic, Quaternion.identity);
                core.ReducirEdificio(edificioAPoner);
                medidor.MedirEdificios();
            }
            else
            {
                Debug.Log("EdificiosAPoner: " + core.RevisarCuantoFaltaPorPoner(edificioAPoner));
            }

        }
    }

    public void EdificoElegido(int edificioElegido)
    {
        edificioAPoner = edificioElegido;
    }
}

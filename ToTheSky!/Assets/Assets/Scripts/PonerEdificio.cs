using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerEdificio : MonoBehaviour
{
    public GameObject[] edificios;
    public GameObject[] edificiosPreview;
    MedidorDeAltura medidor;
    public GameObject camara;
    GameObject preview;
    public int edificioAPoner;
    bool clickDeBoton;

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
            TratarDeConstruir();
            Destroy(preview);

        }
        else
        {
            Vector2 posicionDelClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(posicionDelClic.y > camara.transform.position.y - 2.5f && core.RevisarCuantoFaltaPorPoner(edificioAPoner) > 0)
            {
                if (preview == null)
                {
                    preview = Instantiate(edificiosPreview[edificioAPoner]);
                }

                if (preview != null)
                {
                    preview.transform.position = posicionDelClic;
                }

                
            }
            else
            {
                Destroy(preview);
            }
        }
    }

    public void TratarDeConstruir()
    {
        if (!clickDeBoton)
        {
            Vector2 posicionDelClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(posicionDelClic.y > camara.transform.position.y -2.5f  && core.RevisarCuantoFaltaPorPoner(edificioAPoner) > 0)
            {
                if(posicionDelClic.y < medidor.altura + 10)
                {
                    Instantiate(edificios[edificioAPoner], posicionDelClic, Quaternion.identity);
                    core.ReducirEdificio(edificioAPoner);
                    medidor.MedirEdificios();
                }
                else
                {
                    Debug.Log("No puedes construir tan alto");
                }
                
            }
        }
    }

    void PrevisualizarEdificio()
    {
        
    }
    public void EdificoElegido(int edificioElegido)
    {
        edificioAPoner = edificioElegido;
    }
}

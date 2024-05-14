using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerEdificio : MonoBehaviour
{
    public GameObject[] edificios;
    public GameObject[] edificiosPreview;
    MedidorDeAltura medidor;
    public Color señalado;
    public GameObject camara;
    GameObject preview;
    public int edificioAPoner;
    bool quitarEdificio;
    bool clickDeBoton;
    Tutorial tutorial;

    Puntuacion_Mejora puntuacion;

    Core core;

    private void Start()
    {
        if (GameObject.Find("TUTORIAL") != null)
        {
            tutorial = GameObject.Find("TUTORIAL").GetComponent<Tutorial>();
        }
        edificioAPoner = 0;
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        core = GameObject.Find("Core").GetComponent<Core>();
        puntuacion = GameObject.Find("Puntuacion").GetComponent<Puntuacion_Mejora>();
    }

    void Update()
    {
        if (edificioAPoner == 3 && !tutorial.tutorialLavaMostrado)
        {
            tutorial.tutorialActivo = true;
            tutorial.tutorialActual = 100;
        }
        if (tutorial != null)
        {
            if (!tutorial.tutorialActivo)
            {
                AccionesPrincipales();
            }
        }
        else
        {
            AccionesPrincipales();
        }
    }

    public void AccionesPrincipales()
    {

        Vector2 posicionDelClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (quitarEdificio && core.edificiosADestruir > 0 && posicionDelClic.y > camara.transform.position.y - 2.5f)
        {
            // Convierte la posición del mouse de la pantalla a un rayo en el mundo 3D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            // Si el rayo intersecta con un GameObject
            if (hit.collider != null)
            {
                // Verifica si el GameObject intersectado es el que queremos destruir
                if (hit.collider.gameObject.CompareTag("Edificio"))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Destruye el GameObject
                        Debug.Log("Destruido");
                        Destroy(hit.collider.gameObject);
                        core.edificiosADestruir--;
                    }
                    else
                    {

                        hit.collider.gameObject.GetComponent<Necesidades_casa>().siendoSeleccionada = true;
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = señalado;
                    }

                }
            }


        }
        else if (Input.GetMouseButtonDown(0))
        {
            TratarDeConstruir();
            Destroy(preview);

        }
        else
        {
            if (posicionDelClic.y > medidor.altura + 5)
            {
                if (preview != null)
                {
                    Destroy(preview);
                }
            }
            else if (posicionDelClic.y > camara.transform.position.y - 2.5f && core.RevisarCuantoFaltaPorPoner(edificioAPoner) > 0)
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
                if(posicionDelClic.y < medidor.altura + 5)
                {
                    Instantiate(edificios[edificioAPoner], posicionDelClic, Quaternion.identity);
                    core.ReducirEdificio(edificioAPoner);
                    puntuacion.AumentarPuntuacion(edificioAPoner + 1);
                    medidor.MedirEdificios();
                }
                else
                {
                    Debug.Log("No puedes construir tan alto");
                }
                
            }
        }
    }

    public void EdificoElegido(int edificioElegido)
    {

        edificioAPoner = edificioElegido;
        if (edificioElegido == 10) 
        {
            quitarEdificio = true; 
        }
        else 
        {
            quitarEdificio = false; 
        }
        
    }
}

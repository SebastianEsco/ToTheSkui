using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Necesidades_casa : MonoBehaviour
{
    SpriteRenderer sr;

    public GameObject testigoElectricidad, testigoIglesia;

    public bool iglesia, electricidad; //Las necesidades que puede tener un edificio

    public bool necesidadIglesiaCumplida, necesidadElectricidadCumplida;

    public int distanciaAIglesia, distanciaAElectricidad;
    public int cantidadDeEdificiosDeElectricidadCerca, cantidadDeEdificiosDeIglesiaCerca;
    public int cantidadDeNecesidades, cantidadDeNecesidadesCumplidas;

    int diaEnElQueSePuso;
    MedidorDeAltura medidor;
    Core core;
    private void Start()
    {
        core = GameObject.Find("Core").GetComponent<Core>();
        diaEnElQueSePuso = core.diasTrasncurridos;
        sr = GetComponent<SpriteRenderer>();
        
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        Debug.Log(gameObject);

        if(iglesia)
        {
            cantidadDeNecesidades++;
            testigoIglesia.SetActive(false);
        }
        if (electricidad)
        {
            cantidadDeNecesidades++;
            testigoElectricidad.SetActive(false);
        }
    }

    private void Update()
    {
        EstadoDeLaNeceidad();
        RevisarNecesidades();
        
    }

    public void RevisarNecesidades()
    {
        GameObject[] edificios = GameObject.FindGameObjectsWithTag("Edificio"); //Distancia entre 2 puntos Raiz((Xf - Xi)2 + (Yf - Yi)2)


        cantidadDeEdificiosDeIglesiaCerca = 0; cantidadDeEdificiosDeElectricidadCerca = 0;

        foreach (var edificio in edificios)
        {
            double distanciaAlEdifico = Math.Sqrt(Math.Pow(transform.position.x - edificio.transform.position.x, 2) +
                Math.Pow(transform.position.y - edificio.transform.position.y, 2));


            if (edificio.name == "Electricidad(Clone)" && distanciaAlEdifico < distanciaAElectricidad)
            {
                cantidadDeEdificiosDeElectricidadCerca++;
            }

            if (edificio.name == "Iglesia(Clone)" && distanciaAlEdifico < distanciaAIglesia)
            {
                cantidadDeEdificiosDeIglesiaCerca++;
            }

        }


        if (cantidadDeEdificiosDeIglesiaCerca != 0)
        {
            necesidadIglesiaCumplida = true;
        }
        else necesidadIglesiaCumplida = false;

        if (cantidadDeEdificiosDeElectricidadCerca != 0)
        {
            necesidadElectricidadCumplida = true;
        }
        else necesidadElectricidadCumplida = false;
    }

    public void EstadoDeLaNeceidad()
    {
        cantidadDeNecesidadesCumplidas = 0;

        if(electricidad)
        {
            if (necesidadElectricidadCumplida)
            {
                cantidadDeNecesidadesCumplidas++;
                testigoElectricidad.SetActive(false);
            }
            else
            {
                testigoElectricidad.SetActive(true);
            }
            
        }
        if (iglesia)
        {
            if (necesidadIglesiaCumplida)
            {
                cantidadDeNecesidadesCumplidas++;
                testigoIglesia.SetActive(false);
            }
            else
            {
                testigoIglesia.SetActive(true);
            }
        }

        if(cantidadDeNecesidades == cantidadDeNecesidadesCumplidas)
        {
            //TODO MELO PUEDE SEGUIR BIEN
            sr.color = Color.white;
            diaEnElQueSePuso = core.diasTrasncurridos;
        }
        else
        {
            if(diaEnElQueSePuso == core.diasTrasncurridos - 1)
            {
                sr.color = Color.yellow;
            }
            else if(diaEnElQueSePuso == core.diasTrasncurridos - 2)
            {
                sr.color = Color.red;
            }
            else if(diaEnElQueSePuso == core.diasTrasncurridos - 3)
            {
                sr.color = Color.black;

                core.habitanteInconforme = true;
                Debug.Log("FALLASTE CON LAS NECESIDADES DE UN HABITANTE");
            }
            
        }
        
    }
    

}

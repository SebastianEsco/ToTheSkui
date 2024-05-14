using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Necesidades_casa : MonoBehaviour
{
    SpriteRenderer sr;
    public bool siendoSeleccionada;
    float tiempoDeRevisionSiYaNoEstaSeleccionada;

    public GameObject testigoElectricidad, testigoIglesia, testigoCalor;

    public bool iglesia, electricidad,calor; //Las necesidades que puede tener un edificio
                                      //Calor se refiere a lava

    public bool necesidadIglesiaCumplida, necesidadElectricidadCumplida, necesidadCalorCumplida;

    public float distanciaAIglesia, distanciaAElectricidad, distanciaALava;
    public int cantidadDeEdificiosDeElectricidadCerca, cantidadDeEdificiosDeIglesiaCerca, cantidadDeEdificiosDeLavaCerca;
    public int cantidadDeNecesidades, cantidadDeNecesidadesCumplidas;

    float tiempoParaQueFuncioneLaCalmada;
    bool subirEnojo, subirEnojo2;

    MejorasAEdificios mejoras;

    int diaEnElQueSePuso;
    MedidorDeAltura medidor;
    Core core;
    private void Start()
    {
        tiempoDeRevisionSiYaNoEstaSeleccionada = 0.2f;
        tiempoParaQueFuncioneLaCalmada = 10f;
        core = GameObject.Find("Core").GetComponent<Core>();
        diaEnElQueSePuso = core.diasTrasncurridos;
        sr = GetComponent<SpriteRenderer>();
        mejoras = GameObject.Find("LevelManager").GetComponent<MejorasAEdificios>();
        
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
        if (calor)
        {
            cantidadDeNecesidades++;
            testigoCalor.SetActive(false);
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


            if (edificio.name == "Electricidad(Clone)" && distanciaAlEdifico < distanciaAElectricidad + mejoras.bonus[1])
            {
                cantidadDeEdificiosDeElectricidadCerca++;
            }

            if (edificio.name == "Iglesia(Clone)" && distanciaAlEdifico < distanciaAIglesia + mejoras.bonus[0])
            {
                cantidadDeEdificiosDeIglesiaCerca++;
            }

            if (edificio.name == "Lava(Clone)" && distanciaAlEdifico < distanciaALava + mejoras.bonus[2])
            {
                cantidadDeEdificiosDeLavaCerca++;
            }

        }


        //Revision Iglesia
        if (cantidadDeEdificiosDeIglesiaCerca != 0)
        {
            necesidadIglesiaCumplida = true;
        }
        else necesidadIglesiaCumplida = false;


        //Revision electricidad
        if (cantidadDeEdificiosDeElectricidadCerca != 0)
        {
            necesidadElectricidadCumplida = true;
        }
        else necesidadElectricidadCumplida = false;


        //Revision Lava
        if (cantidadDeEdificiosDeLavaCerca != 0 || transform.position.y < 5)
        {
            necesidadCalorCumplida = true;
        }
        else necesidadCalorCumplida = false;
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

        if (calor)
        {
            if (necesidadCalorCumplida)
            {
                cantidadDeNecesidadesCumplidas++;
                testigoCalor.SetActive(false);
            }
            else
            {
                testigoCalor.SetActive(true);
            }
        }

        if(!siendoSeleccionada)
        {
            if (cantidadDeNecesidades == cantidadDeNecesidadesCumplidas || diaEnElQueSePuso == core.diasTrasncurridos)
            {

                sr.color = Color.white;
                tiempoParaQueFuncioneLaCalmada -= Time.deltaTime;

                if (tiempoParaQueFuncioneLaCalmada < 0)
                {
                    RevisarSiCumplioMomentaneo();
                }
            }
            else
            {
                tiempoParaQueFuncioneLaCalmada = 10f;
                if (diaEnElQueSePuso == core.diasTrasncurridos - 1)
                {
                    sr.color = Color.yellow;
                    if (!subirEnojo)
                    {
                        core.edificiosDesbordados++;
                        subirEnojo = true;
                    }
                }
                else if (diaEnElQueSePuso == core.diasTrasncurridos - 2)
                {
                    sr.color = Color.red;
                    if (!subirEnojo2)
                    {
                        core.edificiosDesbordados++;
                        subirEnojo2 = true;
                    }
                }
                else if (diaEnElQueSePuso == core.diasTrasncurridos - 3)
                {
                    sr.color = Color.black;

                    core.habitanteInconforme = true;
                }

            }

        }
        else
        {
            RevisarSiYaNoEstaSeleccionada();
        }
        
    }

    public void RevisarSiCumplioMomentaneo()
    {
        if (cantidadDeNecesidades == cantidadDeNecesidadesCumplidas)
        {
            //TODO MELO PUEDE SEGUIR BIEN
            subirEnojo = false;
            subirEnojo2 = false;
            diaEnElQueSePuso = core.diasTrasncurridos;
        }
    }

    public void RevisarSiYaNoEstaSeleccionada()
    {
        tiempoDeRevisionSiYaNoEstaSeleccionada -= Time.deltaTime;
        if(tiempoDeRevisionSiYaNoEstaSeleccionada < 0)
        {
            siendoSeleccionada = false;
            tiempoDeRevisionSiYaNoEstaSeleccionada = 0.1f;
        }
    }




}

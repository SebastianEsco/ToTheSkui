using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Core : MonoBehaviour
{
    public int diasTrasncurridos;
    public float alturaNecesaria;

    //Crear un int por cada edificio que será necesario en el dia
    public List<int> edificiosDelDia = new List<int>();
    int edificiosTotalesPorPoner;

    //Bools para saber si se puede seguir jugando
    public bool jugandoDia, habitanteInconforme;


    //Textos para actualizar
    public TextMeshProUGUI textoDiaActual, textoAlturaNecesaria;


    //Texto de cada botón para actualizar cuanto toca poner de ese específico
    public List<TextMeshProUGUI> textosDeLosBotones = new List<TextMeshProUGUI>();

    MedidorDeAltura medidor;
    ManejadorUI manejadorUI;

    
    public GameObject mostrarAlturaNecesaria; //La barrita que muestra la altura que se necesita
    public Color colorPorDebajo, colorPorEncima; //Los colores de la barrita


    public int edificiosDesbordados, cantidadDeEdificiosQuePuedenCaer; //Cuenta los edificios que se han caido y los que se pueden caer


    int contadorParaCasasGrandes;
    private void Start()
    {
        cantidadDeEdificiosQuePuedenCaer = 1; //Para que incie el día 1 la primera vez, si es = 0 no entra
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        manejadorUI = GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>();
        IniciarDia();
    }

    public void IniciarDia()
    {
        if(!habitanteInconforme && (edificiosDesbordados != cantidadDeEdificiosQuePuedenCaer))
        {
            diasTrasncurridos++;
            cantidadDeEdificiosQuePuedenCaer = diasTrasncurridos * 3;
            textoDiaActual.text = "Día: " + diasTrasncurridos;
            alturaNecesaria += 0.4f * diasTrasncurridos;
            textoAlturaNecesaria.text = "Altura necesaria: " + alturaNecesaria;


            //Edificios del día

            edificiosDelDia[0] += Convert.ToInt32(1.75f * diasTrasncurridos);
            edificiosDelDia[1] += 1 + (diasTrasncurridos / 2);
            edificiosDelDia[2] += diasTrasncurridos;

            if(diasTrasncurridos%3 == 0)
            {
                edificiosDelDia[3] += Convert.ToInt32(diasTrasncurridos/2.5f);
            }
            else
            {
                edificiosDelDia[3] += 0;
            }


            if (diasTrasncurridos % 4 == 0)
            {
                edificiosDelDia[4] += Convert.ToInt32(diasTrasncurridos / 4) + contadorParaCasasGrandes;
                contadorParaCasasGrandes++;
            }
            else
            {
                edificiosDelDia[4] += 0;
            }




            foreach (var cantidad in edificiosDelDia)
            {
                if(cantidad > 0)
                {
                    edificiosTotalesPorPoner += cantidad;
                }
            }
            jugandoDia = true;
        }
        
        
    }

    public void Update()
    {
        //Linea de la altura minima
        mostrarAlturaNecesaria.transform.position = new Vector2(mostrarAlturaNecesaria.transform.position.x, alturaNecesaria + 0.4f); //Actualizar el mostrador de altura

        if(alturaNecesaria > medidor.altura)
        {
            mostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorDebajo;
        }
        else
        {
            mostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorEncima;
        }



        if (habitanteInconforme || (edificiosDesbordados >= cantidadDeEdificiosQuePuedenCaer))
        {

            //TRIGGER PANTALLA DE DERROTA
            if (habitanteInconforme)
            {
                manejadorUI.MostrarQueSePerdio("No supliste las necesidades de un habitante");
            }
            else
            {
                manejadorUI.MostrarQueSePerdio("Demasiados habitantes cayeron :(");
            }


            for (int i = 0; i < edificiosDelDia.Count; i++)
            {
                edificiosDelDia[i] = 0;
            }
        }


        if (jugandoDia)
        {
            if (edificiosTotalesPorPoner == 0 )
            {
                jugandoDia = false;
                Invoke("FinDeDia", 3f);
            }

            //Actualizar cuantos edificios falta poner
            for (int i = 0; i < textosDeLosBotones.Count; i++)
            {
                textosDeLosBotones[i].text = edificiosDelDia[i].ToString();
            }

        }
    }

    public int RevisarCuantoFaltaPorPoner(int index)
    {
        if(index == 0) //Casa
        {
            return edificiosDelDia[0];
        }
        if (index == 1) //Iglesia
        {
            return edificiosDelDia[1];
        }
        if (index == 2) //Energia
        {
            return edificiosDelDia[2];
        }
        if (index == 3) //lava
        {
            return edificiosDelDia[3];
        }
        if(index == 4) //Casa grandes
        {
            return edificiosDelDia[4];
        }
        return -1;
    }

    public void ReducirEdificio(int index)
    {
        edificiosTotalesPorPoner--;
        if (index == 0) //Casas
        {
            edificiosDelDia[0]--;
        }
        if (index == 1) //Iglesias
        {
            edificiosDelDia[1]--;
        }
        if (index == 2) //Energia
        {
            edificiosDelDia[2]--;
        }
        if (index == 3) //Lava
        {
            edificiosDelDia[3]--;
        }
        if (index == 4) //Casas grandes
        {
            edificiosDelDia[4]--;
        }
    }

    public void FinDeDia()
    {
        if (medidor.altura > alturaNecesaria)
        {
            if (!habitanteInconforme)
            {
                Debug.Log("Dia completado");

                ActivarCambioDeDia();
            }
        }
        else
        {
            manejadorUI.MostrarQueSePerdio("No llegaste a la altura");
            Debug.Log("No llegaste a la altura :(");
        }
        
    }

    public void ActivarCambioDeDia()
    {
        GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>().MostrarHabilidades(true);
    }



}

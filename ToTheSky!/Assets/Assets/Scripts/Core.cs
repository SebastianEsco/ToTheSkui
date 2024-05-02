using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Core : MonoBehaviour
{
    public int diasTrasncurridos;
    float alturaNecesaria;

    //Crear un int por cada edificio que será necesario en el dia
    int casasDelDia, iglesiasDelDia, electricidadDelDia, lavaDelDia, casasGrandesDelDia, edificiosTotalesPorPoner;

    //Bools para saber si se puede seguir jugando
    public bool jugandoDia, habitanteInconforme;


    //Textos para actualizar
    public TextMeshProUGUI textoDiaActual, textoAlturaNecesaria;


    //Texto de cada botón para actualizar cuanto toca poner de ese específico
    public TextMeshProUGUI textoDeBotonCasa, textoDeBotonIglesia, textoDeBotonElectricidad, textoDeBotonLava, textoBotonCasaGrande;
    //TODO: Hacer esto una lista

    MedidorDeAltura medidor;

    
    public GameObject mostrarAlturaNecesaria; //La barrita que muestra la altura que se necesita
    public Color colorPorDebajo, colorPorEncima; //Los colores de la barrita


    public int edificiosDesbordados, cantidadDeEdificiosQuePuedenCaer; //Cuenta los edificios que se han caido y los que se pueden caer


    int contadorParaCasasGrandes;
    private void Start()
    {
        cantidadDeEdificiosQuePuedenCaer = 1; //Para que incie el día 1 la primera vez, si es = 0 no entra
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
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


            casasDelDia = Convert.ToInt32(1.75f * diasTrasncurridos);
            iglesiasDelDia = 1 + (diasTrasncurridos / 2);
            electricidadDelDia = diasTrasncurridos;

            if(diasTrasncurridos%3 == 0)
            {
                lavaDelDia = Convert.ToInt32(diasTrasncurridos/2.5f);
            }
            else
            {
                lavaDelDia = 0;
            }


            if (diasTrasncurridos % 4 == 0)
            {
                casasGrandesDelDia = Convert.ToInt32(diasTrasncurridos / 4) + contadorParaCasasGrandes;
                contadorParaCasasGrandes++;
            }
            else
            {
                casasGrandesDelDia = 0;
            }


            edificiosTotalesPorPoner = casasDelDia + iglesiasDelDia + electricidadDelDia + lavaDelDia + casasGrandesDelDia;
            jugandoDia = true;
        }
        
        
    }

    public void Update()
    {
        mostrarAlturaNecesaria.transform.position = new Vector2(mostrarAlturaNecesaria.transform.position.x, alturaNecesaria + 0.4f); //Actualizar el mostrador de altura

        if(alturaNecesaria > medidor.altura)
        {
            mostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorDebajo;
        }
        else
        {
            mostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorEncima;
        }

        if (habitanteInconforme || (edificiosDesbordados == cantidadDeEdificiosQuePuedenCaer))
        {
            Debug.Log("Perdió por sapo");
            casasDelDia = 0; iglesiasDelDia = 0; electricidadDelDia = 0;
        }
        if (jugandoDia)
        {
            if (edificiosTotalesPorPoner == 0 )
            {
                jugandoDia = false;
                Invoke("FinDeDia", 3f);
            }

            //Actualizar cuantos edificios falta poner
            textoDeBotonCasa.text = casasDelDia.ToString();
            textoDeBotonIglesia.text = iglesiasDelDia.ToString();
            textoDeBotonElectricidad.text = electricidadDelDia.ToString();
            textoDeBotonLava.text = lavaDelDia.ToString();
            textoBotonCasaGrande.text = casasGrandesDelDia.ToString();

        }
    }

    public int RevisarCuantoFaltaPorPoner(int index)
    {
        if(index == 0)
        {
            return casasDelDia;
        }
        if (index == 1)
        {
            return iglesiasDelDia;
        }
        if (index == 2)
        {
            return electricidadDelDia;
        }
        if (index == 3)
        {
            return lavaDelDia;
        }
        if(index == 4)
        {
            return casasGrandesDelDia;
        }
        return -1;
    }

    public void ReducirEdificio(int index)
    {
        edificiosTotalesPorPoner--;
        if (index == 0)
        {
            casasDelDia--;
        }
        if (index == 1)
        {
            iglesiasDelDia--;
        }
        if (index == 2)
        {
            electricidadDelDia--;
        }
        if (index == 3)
        {
            lavaDelDia--;
        }
        if (index == 4)
        {
            casasGrandesDelDia--;
        }
    }

    public void FinDeDia()
    {
        if (medidor.altura > alturaNecesaria)
        {
            if (!habitanteInconforme)
            {
                Debug.Log("Dia completado");
                
                Invoke("IniciarDia", 0.5f);
            }
        }
        else
        {
            Debug.Log("No llegaste a la altura :(");
        }
        
    }



}

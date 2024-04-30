using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Core : MonoBehaviour
{
    public int diasTrasncurridos;
    float alturaNecesaria;
    int casasDelDia, iglesiasDelDia, electricidadDelDia, lavaDelDia, edificiosTotalesPorPoner;
    public bool jugandoDia, habitanteInconforme;

    public TextMeshProUGUI textoDiaActual, textoAlturaNecesaria;

    public TextMeshProUGUI textoDeBotonCasa, textoDeBotonIglesia, textoDeBotonElectricidad;

    MedidorDeAltura medidor;


    public int edificiosDesbordados, cantidadDeEdificiosQuePuedenCaer;

    private void Start()
    {
        cantidadDeEdificiosQuePuedenCaer = 1; //Para que entre la primera vez, si es 0 no entra
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


            casasDelDia = 2 * diasTrasncurridos;
            iglesiasDelDia = 1 + (diasTrasncurridos / 2);
            electricidadDelDia = diasTrasncurridos;
            lavaDelDia = 0;

            edificiosTotalesPorPoner = casasDelDia + iglesiasDelDia + electricidadDelDia + lavaDelDia;
            jugandoDia = true;
        }
        
        
    }

    public void Update()
    {

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
            textoDeBotonCasa.text = casasDelDia.ToString();
            textoDeBotonIglesia.text = iglesiasDelDia.ToString();
            textoDeBotonElectricidad.text = electricidadDelDia.ToString();
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

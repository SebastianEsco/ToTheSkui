using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Core : MonoBehaviour
{
    int diasTrasncurridos;
    float alturaNecesaria;
    int casasDelDia, iglesiasDelDia, electricidadDelDia, lavaDelDia, edificiosTotalesPorPoner;
    bool jugandoDia;

    public TextMeshProUGUI textoDiaActual, textoAlturaNecesaria;

    public TextMeshProUGUI textoDeBotonCasa, textoDeBotonIglesia, textoDeBotonElectricidad;

    MedidorDeAltura medidor;

    private void Start()
    {
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        IniciarDia();
    }

    public void IniciarDia()
    {
        diasTrasncurridos++;
        textoDiaActual.text = "Día: " +  diasTrasncurridos;
        alturaNecesaria += 1.2f * diasTrasncurridos;
        textoAlturaNecesaria.text = "Altura necesaria: " + alturaNecesaria;
        

        casasDelDia = 3 * diasTrasncurridos;
        iglesiasDelDia = (diasTrasncurridos/2);
        electricidadDelDia = diasTrasncurridos;
        lavaDelDia = 0;

        edificiosTotalesPorPoner = casasDelDia + iglesiasDelDia + electricidadDelDia + lavaDelDia;
        jugandoDia = true;
        
        
    }

    public void Update()
    {
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
            Debug.Log("Dia completado");
            jugandoDia = true;
            IniciarDia();
        }
        else
        {
            Debug.Log("No llegaste a la altura :(");
        }
        
    }



}

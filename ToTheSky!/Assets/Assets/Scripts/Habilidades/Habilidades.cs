using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    public int indexHabilidad;
    Core core;
    MejorasAEdificios mejoras;

    private void Start()
    {
        core = GameObject.Find("Core").GetComponent<Core>();
        mejoras = GameObject.Find("LevelManager").GetComponent<MejorasAEdificios>();
    }

    public void OnHabilidadEscogida()
    {
        switch (indexHabilidad)
        {
            case 0: //Habilidad 0 va a ser conseguir 1 de lava extra en el proximo día

                core.edificiosDelDia[3] += 1;

                break;

            case 1: //Habilidad de mejorar el rango de la energía

                mejoras.MejorarEdificio(1,0.5f);

                break;

            case 2: //Habilidad de mejorar el rango de la energía

                mejoras.MejorarEdificio(0, 0.5f);

                break;

            default:
                break;
        }

        GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>().MostrarHabilidades(false);
        core.IniciarDia();

    }
}

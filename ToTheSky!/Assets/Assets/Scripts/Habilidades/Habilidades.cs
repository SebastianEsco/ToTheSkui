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

                mejoras.MejorarEdificio(1,0.3f);

                break;

            case 2: //Habilidad de mejorar el rango de la iglesia

                mejoras.MejorarEdificio(0, 0.3f);

                break;

            case 3: //Reduce la ira de los habitantes

                Debug.Log("Holi");
                core.edificiosDesbordados -= 5;

                break;

             case 4: //Bajar altura
                core.alturaNecesaria -= core.diasTrasncurridos * 0.3f;
                break;

            case 5: //Aumenta rango de energía, reduce el de las iglesias

                mejoras.MejorarEdificio(1, 0.75f);
                mejoras.MejorarEdificio(0, -0.75f);
                break;

            default:
                break;
        }

        GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>().MostrarHabilidades(false);
        core.IniciarDia();

    }
}

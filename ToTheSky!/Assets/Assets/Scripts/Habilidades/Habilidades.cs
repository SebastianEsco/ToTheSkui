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
            case 0: //Habilidad 0 va a ser conseguir 1 de lava extra en el proximo d�a

                core.edificiosDelDia[3] += 1;

                break;

            case 1: //Habilidad de mejorar el rango de la energ�a

                mejoras.MejorarEdificio(1,0.3f);

                break;

            case 2: //Habilidad de mejorar el rango de la iglesia

                mejoras.MejorarEdificio(0, 0.3f);

                break;

            case 3: //Reduce la ira de los habitantes

                core.edificiosDesbordados -= 5;

                break;

             case 4: //Bajar altura
                core.alturaNecesaria -= core.diasTrasncurridos * 0.3f;
                break;

            case 5: //Aumenta rango de energ�a, reduce el de las iglesias

                mejoras.MejorarEdificio(1, 0.55f);
                mejoras.MejorarEdificio(0, -0.33f);
                break;

            default:
                break;

            case 6: //Da 3 cargas de destruir edificios

                core.edificiosADestruir += 3;
                break;

            case 7: //Salvar de explosi�n

                core.inmunidadAExplosion += 1;
                break;

        }

        GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>().MostrarHabilidades(false);
        core.IniciarDia();

    }
}

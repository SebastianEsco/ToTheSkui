using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mejoras : MonoBehaviour
{
    public int indexHabilidad;
    Core core;
    MejorasAEdificios mejoras;

    private void Start()
    {
        core = GameObject.Find("Core").GetComponent<Core>();
        //mejoras = GameObject.Find("LevelManager").GetComponent<MejorasAEdificios>();
    }

    //public void OnHabilidadEscogida()
    //{
    //    switch (indexHabilidad)
    //    {
    //        case 0: //Habilidad 0 va a ser conseguir 1 de lava extra en el proximo d�a

    //            if (core.puntuacion>=30)
    //            {
    //               // core.edificiosDelDia[3] += 1;
    //                Debug.Log(" se compro mejora 0");
    //                core.puntuacion = core.puntuacion - 30;
    //            }
    //            else
    //            {
    //                Debug.Log("No se pudo comprar mejora 0");
    //            }

    //            break;

    //        case 1: //Habilidad de mejorar el rango de la energ�a
    //            if(core.puntuacion>=30)
    //            {

    //                Debug.Log("se compr� mejora 1");
    //                core.puntuacion = core.puntuacion - 30;
    //            }
                
    //            else
    //            {
    //                Debug.Log("no se pudo comprar mejora 1");
    //            }

    //            break;

    //        case 2: //Habilidad de mejorar el rango de la iglesia

    //            if (core.puntuacion >= 30)
    //            {
    //                Debug.Log("se compr� mejora 2");
    //                core.puntuacion = core.puntuacion - 30;
    //            }

    //            else
    //            {
    //                Debug.Log("no se pudo comprar mejora 2");
    //            }

    //            break;

    //        case 3: //Reduce la ira de los habitantes

    //            if (core.puntuacion >= 30)
    //            {
    //                Debug.Log("se compr� mejora 3");
    //                Puntuacion_Mejora.puntuacion = core.puntuacion - 30;
    //            }

    //            else
    //            {
    //                Debug.Log("no se pudo comprar mejora 3");
    //            }

    //            break;

    //        case 4: //Bajar altura
    //            if (core.puntuacion >= 30)
    //            {
    //                Debug.Log("se compr� mejora 4");
    //                core.puntuacion = core.puntuacion - 30;
    //            }

    //            else
    //            {
    //                Debug.Log("no se pudo comprar mejora 4");
    //            }
    //            break;

    //        case 5: //Aumenta rango de energ�a, reduce el de las iglesias

    //            if (core.puntuacion >= 30)
    //            {
    //                Debug.Log("se compr� mejora 5");
    //                core.puntuacion = core.puntuacion - 30;
    //            }

    //            else
    //            {
    //                Debug.Log("no se pudo comprar mejora 5");
    //            }
    //            break;

    //        default:
    //            break;
    //    }

    //    GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>().MostrarHabilidades(false);
    //    core.IniciarDia();

    //}
}

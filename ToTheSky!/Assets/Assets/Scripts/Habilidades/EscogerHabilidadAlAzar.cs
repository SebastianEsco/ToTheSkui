using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscogerHabilidadAlAzar : MonoBehaviour
{
    public List<GameObject> habilidades = new List<GameObject>();
    public GameObject habilidad1, habilidad2, habilidad3;
    int[] numerosAleatorios = new int[3];
    int habilidadesRepartidas;

    public void RepartirHabilidades()
    {
        int contador = 0;
        habilidadesRepartidas = 0;
        while (habilidadesRepartidas != 3)
        {
            int numero = Random.Range(0, habilidades.Count);
            if(numero == 4 && GameObject.Find("Core").GetComponent<Core>().diasTrasncurridos < 3)
            {
                Debug.Log("Salio la de bajar el limite pero no se aplicó");
                continue;
            }
            numerosAleatorios[contador] = numero;
            contador++;
            habilidadesRepartidas++;
        }


        habilidad1 = habilidades[numerosAleatorios[0]];
        habilidad2 = habilidades[numerosAleatorios[1]];
        habilidad3 = habilidades[numerosAleatorios[2]];
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscogerHabilidadAlAzar : MonoBehaviour
{
    public List<GameObject> habilidades = new List<GameObject>();
    public GameObject habilidad1, habilidad2, habilidad3;

    public void RepartirHabilidades()
    {

        habilidad1 = habilidades[Random.Range(0, habilidades.Count)];
        habilidad2 = habilidades[Random.Range(0, habilidades.Count)];
        habilidad3 = habilidades[Random.Range(0, habilidades.Count)];
    } 
}

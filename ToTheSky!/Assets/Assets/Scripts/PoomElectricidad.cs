using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoomElectricidad : MonoBehaviour
{
    public float distanciaDeExplosion;
    public GameObject colliderPoom;

    // Update is called once per frame
    void Update()
    {
        GameObject[] edificios = GameObject.FindGameObjectsWithTag("Edificio");
        foreach (var edificio in edificios)
        {
            double distanciaAlEdifico = Math.Sqrt(Math.Pow(transform.position.x - edificio.transform.position.x, 2) +
                Math.Pow(transform.position.y - edificio.transform.position.y, 2));


            if (edificio.name == "Lava(Clone)" && distanciaAlEdifico < distanciaDeExplosion)
            {
                colliderPoom.SetActive(true);
                Destroy(gameObject, 0.3f);
            }


        }
    }
}

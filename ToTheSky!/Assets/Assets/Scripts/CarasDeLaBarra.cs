using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarasDeLaBarra : MonoBehaviour
{
    public GameObject feliz, neutro, nojao;
    Core core;

    public void Start()
    {
        core = GameObject.Find("Core").GetComponent<Core>();
        feliz.SetActive(true);
        nojao.SetActive(false);
        neutro.SetActive(false);
    }

    private void Update()
    {
        float proporcion = (float)core.edificiosDesbordados / (float)core.cantidadDeEdificiosQuePuedenCaer;
        if (core.edificiosDesbordados >= 0)
        {

            if (proporcion < 0.3f)
            {
                feliz.SetActive(true);
                nojao.SetActive(false);
                neutro.SetActive(false);
            }
            else if (proporcion < 0.6f)
            {
                feliz.SetActive(false);
                neutro.SetActive(true);
                nojao.SetActive(false);
            }
            else
            {
                feliz.SetActive(false);
                neutro.SetActive(false);
                nojao.SetActive(true);
            }
        }
        else
        {
            feliz.SetActive(true);
            nojao.SetActive(false);
            neutro.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MedidorDeAltura : MonoBehaviour
{
    public float altura, alturaMomentanea;
    GameObject edificoMasAltoActual;
    public bool midiendo;
    private void Start()
    {
        edificoMasAltoActual = null;
        RevisarAltura();
    }
    void Update()
    {
        
        if(edificoMasAltoActual != null)
        {
            altura = edificoMasAltoActual.transform.position.y;
            
        }
        else
        {
            altura = 0f;
        }

    }

    public void MedirEdificios()
    {
        midiendo = true;
        GameObject[] edificos = GameObject.FindGameObjectsWithTag("Edificio");
        
        foreach (var edificio in edificos)
        {
            if(edificoMasAltoActual != null)
            {
                if (edificoMasAltoActual.transform.position.y < edificio.transform.position.y)
                {
                    edificoMasAltoActual = edificio;
                }
            }
            else
            {
                edificoMasAltoActual = edificio;
            }
            

        }
    }

    public void RevisarAltura()
    {
        if(alturaMomentanea > altura)
        {
            MedirEdificios();
        }
        else
        {
            alturaMomentanea = altura;
            midiendo = false;
        }
        Invoke("RevisarAltura", 0.2f);

    }
}

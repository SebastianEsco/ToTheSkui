using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MedidorDeAltura : MonoBehaviour
{
    public float altura, alturaMomentanea;
    public TextMeshProUGUI textoAltura;
    GameObject edificoMasAltoActual;
    private void Start()
    {
        edificoMasAltoActual = null;
        RevisarAltura();
    }
    void Update()
    {
        
        if(edificoMasAltoActual != null)
        {
            altura = edificoMasAltoActual.transform.position.y + 2f;
            
        }
        else
        {
            altura = 0f;
        }

        

        textoAltura.text = "Altura actual: " + altura.ToString("F1");
    }

    public void MedirEdificios()
    {
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
        }
        Invoke("RevisarAltura", 0.2f);

    }
}

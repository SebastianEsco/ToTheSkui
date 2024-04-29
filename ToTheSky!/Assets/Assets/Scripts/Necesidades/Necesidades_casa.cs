using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necesidades_casa : MonoBehaviour
{
    SpriteRenderer sr;

    public bool iglesia, electricidad; //Las necesidades que puede tener un edificio

    public bool necesidadIglesiaCumplida, necesidadElectricidadCumplida;

    public int distanciaAIglesia, distanciaAElectricidad;
    public int cantidadDeEdificiosDeElectricidadCerca, cantidadDeEdificiosDeIglesiaCerca;
    int cantidadDeNecesidades, cantidadDeNecesidadesCumplidas;
    MedidorDeAltura medidor;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        Debug.Log(gameObject);

        if(iglesia)
        {
            cantidadDeNecesidades++;
        }
        if (electricidad)
        {
            cantidadDeNecesidades++;
        }
    }

    private void Update()
    {
        if (medidor.midiendo)
        {
            RevisarNecesidades();

            EstadoDeLaNeceidad();
        }
    }

    public void RevisarNecesidades()
    {
        GameObject[] edificios = GameObject.FindGameObjectsWithTag("Edificio"); //Distancia entre 2 puntos Raiz((Xf - Xi)2 + (Yf - Yi)2)


        cantidadDeEdificiosDeIglesiaCerca = 0; cantidadDeEdificiosDeElectricidadCerca = 0;

        foreach (var edificio in edificios)
        {
            double distanciaAlEdifico = Math.Sqrt(Math.Pow(transform.position.x - edificio.transform.position.x, 2) +
                Math.Pow(transform.position.y - edificio.transform.position.y, 2));


            if (edificio.name == "Electricidad(Clone)" && distanciaAlEdifico < distanciaAElectricidad)
            {
                cantidadDeEdificiosDeElectricidadCerca++;
            }

            if (edificio.name == "Iglesia(Clone)" && distanciaAlEdifico < distanciaAIglesia)
            {
                cantidadDeEdificiosDeIglesiaCerca++;
            }

        }


        if (cantidadDeEdificiosDeIglesiaCerca != 0)
        {
            necesidadIglesiaCumplida = true;
        }
        else necesidadIglesiaCumplida = false;

        if (cantidadDeEdificiosDeElectricidadCerca != 0)
        {
            necesidadElectricidadCumplida = true;
        }
        else necesidadElectricidadCumplida = false;
    }

    public void EstadoDeLaNeceidad()
    {

        if(electricidad && necesidadElectricidadCumplida)
        {
            cantidadDeNecesidadesCumplidas++;
        }
        if (iglesia && necesidadIglesiaCumplida)
        {
            cantidadDeNecesidadesCumplidas++;
        }


        int intensidadDeRojo = 0 + (255 / cantidadDeNecesidades * cantidadDeNecesidadesCumplidas);
        Debug.Log(intensidadDeRojo);

        Color color = new Color(255,intensidadDeRojo,intensidadDeRojo);
        sr.color = color;
    }
    

}

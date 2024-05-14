using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    Puntuacion_Mejora puntuacionMejoraScript;

    //Para las columnas
    DatosDeMejoras datosDeMejoras;
    public GameObject columnaDerecha, columnaIzquierda;

    //Para las bases
    public GameObject base1, base2, base3, base4;

    public int diasTrasncurridos;
    public float alturaNecesaria;

    public Image Caidos; //la barra que vaa indicar cuantos edificios se han caid

    public int inmunidadAExplosion;

    public GameObject columnas;

    //Crear un int por cada edificio que ser� necesario en el dia
    public List<int> edificiosDelDia = new List<int>();
    int edificiosTotalesPorPoner;

    //Bools para saber si se puede seguir jugando
    public bool jugandoDia, habitanteInconforme;


    //Textos para actualizar
    public TextMeshProUGUI textoDiaActual;


    //Texto de cada bot�n para actualizar cuanto toca poner de ese espec�fico
    public List<TextMeshProUGUI> textosDeLosBotones = new List<TextMeshProUGUI>();
    public TextMeshProUGUI textoBotonDestruirEdificio;
    public int edificiosADestruir;

    MedidorDeAltura medidor;
    ManejadorUI manejadorUI;

    
    public GameObject mostrarAlturaNecesaria, extraMostrarAlturaNecesaria; //La barrita que muestra la altura que se necesita
    public Color colorPorDebajo, colorPorEncima; //Los colores de la barrita


    public int edificiosDesbordados, cantidadDeEdificiosQuePuedenCaer; //Cuenta los edificios que se han caido y los que se pueden caer


    int contadorParaCasasGrandes;

    // PUNTUACION
    //public int puntuacion;
    private void Start()
    {
        datosDeMejoras = GameObject.Find("Puntuacion").GetComponent<DatosDeMejoras>();
        cantidadDeEdificiosQuePuedenCaer = 1; //Para que incie el d�a 1 la primera vez, si es = 0 no entra
        medidor = GameObject.Find("LevelManager").GetComponent<MedidorDeAltura>();
        manejadorUI = GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>();


        puntuacionMejoraScript = GameObject.Find("Puntuacion").GetComponent<Puntuacion_Mejora>();

        //ActivarColumnas
        ActivarColumnas(datosDeMejoras.nivelMejoraColumna);
        //Activar Mejora de estabilidad
        MejorarEstabilidad(datosDeMejoras.nivelMejoraEstabilidad);
        //Activar Bases
        ActivarBases(datosDeMejoras.nivelMejoraBases);




        IniciarDia();
    }

    public void IniciarDia()
    {
        Caidos.fillAmount = 0; //la barra inicia vac�a


        if (!habitanteInconforme && (edificiosDesbordados != cantidadDeEdificiosQuePuedenCaer))
        {
            diasTrasncurridos++;
            cantidadDeEdificiosQuePuedenCaer = diasTrasncurridos * 3;
            textoDiaActual.text = "D�a: " + diasTrasncurridos;
            alturaNecesaria += 0.4f * diasTrasncurridos;


            //Edificios del d�a

            edificiosDelDia[0] += Convert.ToInt32(1.75f * diasTrasncurridos);
            edificiosDelDia[1] += 1 + (diasTrasncurridos / 2);
            edificiosDelDia[2] += diasTrasncurridos;

            if(diasTrasncurridos%3 == 0)
            {
                edificiosDelDia[3] += Convert.ToInt32(diasTrasncurridos/2.5f);
            }
            else
            {
                edificiosDelDia[3] += 0;
            }


            if (diasTrasncurridos % 4 == 0)
            {
                edificiosDelDia[4] += Convert.ToInt32(diasTrasncurridos / 4) + contadorParaCasasGrandes;
                contadorParaCasasGrandes++;
            }
            else
            {
                edificiosDelDia[4] += 0;
            }




            foreach (var cantidad in edificiosDelDia)
            {
                if(cantidad > 0)
                {
                    edificiosTotalesPorPoner += cantidad;
                }
            }
            jugandoDia = true;
        }
        
        
    }

    public void Update()
    {
        ActualizarBarraCaidos();

        //Linea de la altura minima
        if(alturaNecesaria + 0.425f > mostrarAlturaNecesaria.transform.position.y)
        {
            mostrarAlturaNecesaria.transform.Translate(Vector2.up * Time.deltaTime * 0.3f);
        } //Actualizar el mostrador de altura

        if(alturaNecesaria > medidor.altura)
        {
            mostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorDebajo;
            extraMostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorDebajo;
        }
        else
        {
            mostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorEncima;
            extraMostrarAlturaNecesaria.GetComponent<SpriteRenderer>().color = colorPorEncima;
        }



        if (habitanteInconforme || (edificiosDesbordados >= cantidadDeEdificiosQuePuedenCaer))
        {

            //TRIGGER PANTALLA DE DERROTA
            if (habitanteInconforme)
            {
                manejadorUI.MostrarQueSePerdio("No supliste las necesidades de un habitante");
            }
            else
            {
                manejadorUI.MostrarQueSePerdio("La ira de los habitantes ha crecido demasiado");
            }


            for (int i = 0; i < edificiosDelDia.Count; i++)
            {
                edificiosDelDia[i] = 0;
            }
        }


        if (jugandoDia)
        {
            if (edificiosTotalesPorPoner == 0 )
            {
                jugandoDia = false;
                Invoke("FinDeDia", 3f);
                
            }

            //Actualizar cuantos edificios falta poner
            for (int i = 0; i < textosDeLosBotones.Count; i++)
            {
                textosDeLosBotones[i].text = edificiosDelDia[i].ToString();
            }
            textoBotonDestruirEdificio.text = edificiosADestruir.ToString();

        }
    }

    public int RevisarCuantoFaltaPorPoner(int index)
    {
        if(index == 0) //Casa
        {
            return edificiosDelDia[0];
        }
        if (index == 1) //Iglesia
        {
            return edificiosDelDia[1];
        }
        if (index == 2) //Energia
        {
            return edificiosDelDia[2];
        }
        if (index == 3) //lava
        {
            return edificiosDelDia[3];
        }
        if(index == 4) //Casa grandes
        {
            return edificiosDelDia[4];
        }
        return -1;
    }

    public void ReducirEdificio(int index)
    {
        edificiosTotalesPorPoner--;
        if (index == 0) //Casas
        {
            edificiosDelDia[0]--;
        }
        if (index == 1) //Iglesias
        {
            edificiosDelDia[1]--;
        }
        if (index == 2) //Energia
        {
            edificiosDelDia[2]--;
        }
        if (index == 3) //Lava
        {
            edificiosDelDia[3]--;
        }
        if (index == 4) //Casas grandes
        {
            edificiosDelDia[4]--;
        }
    }

    public void FinDeDia()
    {

        if (medidor.altura > alturaNecesaria)
        {
            if (!habitanteInconforme)
            {
                Debug.Log("Dia completado");

                puntuacionMejoraScript.AumentarPuntuacion(5 * diasTrasncurridos);
                ActivarCambioDeDia();
            }
        }
        else
        {
            manejadorUI.MostrarQueSePerdio("No llegaste a la altura");
            Debug.Log("No llegaste a la altura :(");
        }
        
    }

    public void ActivarCambioDeDia()
    {
        GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>().MostrarHabilidades(true);
    }

    public void ActualizarBarraCaidos()
    {
        float progreso = (float) edificiosDesbordados / (float)cantidadDeEdificiosQuePuedenCaer;

        Caidos.fillAmount = progreso;

        
    }

    public void MejorarEstabilidad(int nivelDeLaHabilidad)
    {
        Physics2D.gravity = new Vector2(0, -10 + (nivelDeLaHabilidad));
        if(Physics2D.gravity.y > 0)
        {
            Physics2D.gravity *= -1;
        }
        Debug.Log(Physics2D.gravity);
    }

    public void ActivarColumnas(int nivelDeLaHabilidad)
    {
        if(nivelDeLaHabilidad == 1)
        {
            columnaIzquierda.SetActive(true);
        }
        else if (nivelDeLaHabilidad > 1)
        {
            columnaIzquierda.SetActive(true);
            columnaDerecha.SetActive(true);
        }
    }

    public void ActivarBases(int nivelDeLaHabilidad)
    {
        if (nivelDeLaHabilidad == 1)
        {
            base1.SetActive(true);
        }
        else if (nivelDeLaHabilidad ==2)
        {
            base2.SetActive(true);
            base1.SetActive(true) ;
        }
        else if (nivelDeLaHabilidad == 3)
        {
            base2.SetActive(true);
            base1.SetActive(true);
            base3.SetActive(true);
        }
        else if (nivelDeLaHabilidad > 3)
        {
            base2.SetActive(true);
            base1.SetActive(true);
            base3.SetActive(true);
            base4.SetActive(true);
        }
    }


}

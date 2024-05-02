using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManejadorUI : MonoBehaviour
{
    public GameObject oscurecerEscena, mostrarHabilidades;
    public GameObject habilidad1, habilidad2, habilidad3;
    public TextMeshProUGUI mensajeDeDerrota;
    public GameObject botonDeReiniciar;

    private void Start()
    {
        mensajeDeDerrota.text = "";
    }

    public void MostrarHabilidades(bool activar)
    {
        oscurecerEscena.SetActive(activar);
        mostrarHabilidades.SetActive(activar);
        GetComponent<EscogerHabilidadAlAzar>().RepartirHabilidades();
        habilidad1.GetComponent<InstanciarCarta>().InstanciarObjeto();
        habilidad2.GetComponent<InstanciarCarta>().InstanciarObjeto();
        habilidad3.GetComponent<InstanciarCarta>().InstanciarObjeto();

    }

    public void MostrarQueSePerdio(string razon)
    {
        if(mensajeDeDerrota.text == "")
        {
            oscurecerEscena.SetActive(true);
            mensajeDeDerrota.text += razon;
            botonDeReiniciar.SetActive(true);
        }
        

        
    }
}

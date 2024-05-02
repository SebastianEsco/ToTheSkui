using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarCarta : MonoBehaviour
{
    public int indexHabilidad;
    GameObject habilidad1, habilidad2, habilidad3;
    public void InstanciarObjeto()
    {
        if(indexHabilidad == 0)
        {
            Debug.Log("Instanciando");

            habilidad1 = Instantiate(GameObject.Find("ManejadorUI").GetComponent<EscogerHabilidadAlAzar>().habilidad1,
                transform.position, Quaternion.identity);
            habilidad1.transform.SetParent(transform);
            habilidad1.transform.localPosition = Vector2.zero;

        }
        else if(indexHabilidad == 1)
        {
            habilidad2 = Instantiate(GameObject.Find("ManejadorUI").GetComponent<EscogerHabilidadAlAzar>().habilidad2,
                transform.position, Quaternion.identity);

            habilidad2.transform.SetParent(transform);
            habilidad2.transform.localPosition = Vector2.zero;
        }
        else if (indexHabilidad == 2)
        {
            habilidad3 = Instantiate(GameObject.Find("ManejadorUI").GetComponent<EscogerHabilidadAlAzar>().habilidad3,
                transform.position, Quaternion.identity);

            habilidad3.transform.SetParent(transform);
            habilidad3.transform.localPosition = Vector2.zero;
        }
    }
}

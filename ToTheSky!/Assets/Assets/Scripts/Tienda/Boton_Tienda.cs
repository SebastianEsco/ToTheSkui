using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_Tienda : MonoBehaviour
{
    
    public GameObject Tienda;

    private void Start()
    {
        Tienda.SetActive(false);
    }

    public void OnClick()
    {
        Tienda.SetActive(true);
        
    }
   
    public void OnClick2()
    {
        Tienda.SetActive(false);
    }

    
}

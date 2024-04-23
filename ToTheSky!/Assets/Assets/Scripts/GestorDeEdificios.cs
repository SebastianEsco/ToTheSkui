using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GestorDeEdificios : MonoBehaviour
{
    public int indexEdificio;
    PonerEdificio ponerEdifico;
    private void Start()
    {
        ponerEdifico = GameObject.Find("LevelManager").GetComponent<PonerEdificio>();
    }
    public void OnClick()
    {
        ponerEdifico.EdificoElegido(indexEdificio);
    }
    
}

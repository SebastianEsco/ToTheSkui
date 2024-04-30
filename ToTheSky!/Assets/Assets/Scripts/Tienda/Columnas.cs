using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columnas : MonoBehaviour
{
    public GameObject estructura;


    private void Start()
    {
        estructura.SetActive(false);
    }
    // Start is called before the first frame update
    public void OnClick()
    {
        estructura.SetActive(true);
    }
}

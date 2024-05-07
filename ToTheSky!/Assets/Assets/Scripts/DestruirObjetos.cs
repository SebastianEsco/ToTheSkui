using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edificio"))
        {
            Debug.Log("EDIFICIO MUERTO");
            Destroy(collision.gameObject);
            GameObject.Find("Core").GetComponent<Core>().edificiosDesbordados++;
            

        }
        
        
    }
}

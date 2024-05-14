using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguienteTutotial : MonoBehaviour
{
   public void OnSiguiente()
    {
        GameObject.Find("TUTORIAL").GetComponent<Tutorial>().OnClickSiguiente();
    }

    public void OnOmitirTutorial()
    {
        GameObject.Find("TUTORIAL").GetComponent<Tutorial>().tutorialActivo = false;
    }
}

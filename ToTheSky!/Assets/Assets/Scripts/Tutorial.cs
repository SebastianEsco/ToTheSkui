using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool tutorialActivo;
    public GameObject tutorial1, tutorial2, tutorial3;
    public GameObject tutorialLava, omitirTutorial;
    public bool tutorial1Mostrado, tutorialLavaMostrado;
    public int tutorialActual;
    void Awake()
    {
        tutorialActivo = true;
        omitirTutorial.SetActive(true);
    }

    public void OnClickSiguiente()
    {
        tutorialActual++;
    }

    public void Update()
    {
        if (tutorialActivo)
        {
            switch (tutorialActual)
            {
                case 0:

                    tutorial1.SetActive(true);
                    break;
                case 1:
                    tutorial1.SetActive(false);
                    tutorial2.SetActive(true);
                    break;
                case 2:
                    tutorial1.SetActive(false);
                    tutorial2.SetActive(false);
                    tutorial3.SetActive(true);
                    break;

                case 100:
                    if (!tutorialLavaMostrado)
                    {
                        tutorialLava.SetActive(true);
                        tutorialLavaMostrado = true;
                    }

                    break;



                default:
                    DesactivarTutorial();
                    break;
            }
        }
        else
        {
            DesactivarTutorial();
        }
        


    }

    public void DesactivarTutorial()
    {
        tutorialActivo = false;
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorialLava.SetActive(false);
        omitirTutorial.SetActive(false);
    }

  




}

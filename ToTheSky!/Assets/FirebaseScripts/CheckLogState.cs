using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Extensions;
using TMPro;
using UnityEngine.UI;
public class CheckLogState : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoad = "GameScene";
    [SerializeField]
    private bool _LoadSceneWhenAuthenticated = true;

    public GameObject[] UILogueado, UIDeslogueado;
    public TextMeshProUGUI textoUser;


    // Start is called before the first frame update
    void Start()
    {
        FirebaseAuth.DefaultInstance.StateChanged += HandleAuthStateChange;
        FirebaseAuth.DefaultInstance.StateChanged += HandleAuthChange;
    }

    private void HandleAuthStateChange(object sender, EventArgs e)
    {
        bool isAuthenticated = FirebaseAuth.DefaultInstance.CurrentUser != null;

        if(GameObject.Find("PlayButton") != null)
        {
            GameObject.Find("PlayButton").GetComponent<Button>().interactable = isAuthenticated;
        }

        StartCoroutine(CambiarUIs(isAuthenticated));


    }

    IEnumerator CambiarUIs(bool isAuthenticated)
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject ui in UILogueado)
        {
            ui.SetActive(isAuthenticated);
        }
        foreach (GameObject ui in UIDeslogueado)
        {
            ui.SetActive(!isAuthenticated);
        }

        if (!isAuthenticated) SceneManager.LoadScene(0);

        
    }


    private void HandleAuthChange(object sender, EventArgs e)
    {
        var currentUser = FirebaseAuth.DefaultInstance.CurrentUser;

        if (currentUser != null)
        {
            SetLabelUsername(currentUser.UserId);
        }


    } 

   private void SetLabelUsername(string UserId)
    {
        FirebaseDatabase.DefaultInstance
           .GetReference("users/" + UserId + "/username")
           .GetValueAsync().ContinueWithOnMainThread(task => {
               if (task.IsFaulted)
               {
                   Debug.Log(task.Exception);
                   textoUser.text = "NULL";
               }
               else if (task.IsCompleted)
               {
                   DataSnapshot snapshot = task.Result;
                   Debug.Log(snapshot.Value);
                   textoUser.text = (string)snapshot.Value;

               }
           });
    }



    void OnDestroy()
    {
        FirebaseAuth.DefaultInstance.StateChanged -= HandleAuthStateChange;
    }
}

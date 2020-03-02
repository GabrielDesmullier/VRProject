using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class SceneSwitchSc1 : MonoBehaviour
{
    [UsedImplicitly]

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Changement de Scène"); 
            SceneManager.LoadScene("Menu_Début");
        }
    }
}

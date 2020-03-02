using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class SceneSwitch : MonoBehaviour
{
    private bool change_scene = true;
    public void OnCollisionEnter(Collision collision)
    { 
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Changement de scène");
            change_scene = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; 
            SceneManager.LoadScene("Bibliothèque");
        }
        
    }

    public bool Switch()
    {
        return change_scene;
    }
}

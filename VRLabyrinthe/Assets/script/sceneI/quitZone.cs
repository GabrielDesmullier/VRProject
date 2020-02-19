using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            SceneManager.LoadSceneAsync("Bibliothèque");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

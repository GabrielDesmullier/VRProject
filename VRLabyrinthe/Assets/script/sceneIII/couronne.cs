using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class couronne : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        StartCoroutine(Destruction());
    }

    IEnumerator Destruction()
    {

        yield return new WaitForSeconds(10f);
        Destroy(gameObject);


    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(message: "Success!");
        SceneManager.LoadScene("menu");
        
    }
}

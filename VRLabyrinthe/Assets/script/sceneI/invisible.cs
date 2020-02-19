using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera") 
        {
            other.GetComponent<life>().changeVisible();
            Debug.Log(message: "invisible");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            other.GetComponent<life>().changeVisible();
            Debug.Log(message: "visible");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

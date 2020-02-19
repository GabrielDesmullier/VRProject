using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class augmentevie : MonoBehaviour
{
    // Start is called before the first frame update
    private int don = 10;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MainCamera")
        {
            other.GetComponent<life>().setLifeLevel(other.GetComponent<life>().getLifeLevel()+ don);
            if (don > 0)
            {
                don = don - 1;
            }//pour eviter de recup de la vie n'importe où
            Debug.Log(message: other.GetComponent<life>().getLifeLevel());
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

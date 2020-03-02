using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_mun : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Contact");
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OK");
            Debug.Log(gameObject.name);
            Destroy(gameObject);

        }
    }
}

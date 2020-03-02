using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Life : MonoBehaviour
{
    [SerializeField] private GameObject vie = default;
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(vie, new Vector3(17f,2f,21f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(vie, new Vector3(17f,2f,-21), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(vie, new Vector3(-20f,2f,4f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
    }
}

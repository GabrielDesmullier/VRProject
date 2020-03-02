using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Invinsible : MonoBehaviour
{
    [SerializeField] private GameObject invinsible = default;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(invinsible, new Vector3(15f,2f,-45f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(invinsible, new Vector3(20f,2f,-5), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(invinsible, new Vector3(-46f,2f,33f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
    }
}

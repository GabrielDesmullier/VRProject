using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Zombie : MonoBehaviour
{
    [SerializeField] private GameObject spawn = default;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(spawn, new Vector3(44f,1f,34f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(spawn, new Vector3(44f,1f,-18), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(spawn, new Vector3(-24f,1f,-46f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(spawn, new Vector3(-44f,1f,-25f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(spawn, new Vector3(-44f,1f,3f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(spawn, new Vector3(-28f,1f,45f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
        Instantiate(spawn, new Vector3(44,1f,-46), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
    }
}

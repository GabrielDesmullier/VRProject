using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint = default;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(checkpoint, new Vector3(-6f,2f,-5f), Quaternion.Euler(0f,0f,0f), this.gameObject.transform);
    }
}

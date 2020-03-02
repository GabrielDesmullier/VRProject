using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couronnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject couronne;
    private Transform objectTransform;


    private void Awake()
    {
        objectTransform = transform;
        StartCoroutine(Spawner());
    }

    private Vector3 SpawnZone()
    {
        return new Vector3(Random.Range(4, 30), 0, Random.Range(6, 39));
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(11f);
            objectTransform.position = SpawnZone();
            Instantiate(couronne,objectTransform.position, Quaternion.Euler(-90,0,0), objectTransform);
        }
    }

}

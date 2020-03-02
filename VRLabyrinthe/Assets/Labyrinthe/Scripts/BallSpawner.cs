using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float x;
    [SerializeField] private GameObject prefab = default;
    [SerializeField] private Transform ballsParentsTransform = default;
    [SerializeField] public float spawningSpeed = 3f;
    [SerializeField] public float spawningForce = 5000f;
    private Transform cameraTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        cameraTransform = transform;
    
    }

    public void Update()
    {
        x+= Time.deltaTime*20;
    }

    public void SpawnBall()
    {
        GameObject ball = Instantiate(prefab, cameraTransform.position, Quaternion.Euler(x,x,x), ballsParentsTransform);
        ball.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * spawningForce);
    }
}

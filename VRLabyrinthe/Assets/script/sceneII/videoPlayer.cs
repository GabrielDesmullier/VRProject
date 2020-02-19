using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject video;
    private Transform objectTransform;
    private Transform playerTransform;
    private float distance;
    private void Awake()
    {
        objectTransform = transform;
        playerTransform = player.transform;
        video.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(objectTransform.position, playerTransform.position);
        
        if (distance <= 3f)
        {
            video.SetActive(true);
        }
        else
        {
            video.SetActive(false);
        }
    }
}

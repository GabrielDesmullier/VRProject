using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMouvement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private float speed = 1f;
    private float yawn = 0.0f;
    private float pitch = 0.0f;
    private Transform playerTransform;
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = transform;
        yawn = 0.0f;
        pitch = 0.0f;

    }



    private void Update()
    {
        HandleMovement();
        HandleCameraMovement();
        
    }



    private void HandleMovement()
    {
        Vector3 currentPosition = playerTransform.position;
        Vector3 deltaPosition = (playerTransform.right * Input.GetAxis("Horizontal") + playerTransform.forward * Input.GetAxis("Vertical")) * speed;
        deltaPosition.y = 0f;
        playerTransform.position = currentPosition + deltaPosition;

    }



    private void HandleCameraMovement()
    {
        yawn += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.eulerAngles = new Vector3(pitch, yawn, 0f);
    }
}
   using UnityEngine;
   using System.Collections;
   
   public class characterController : MonoBehaviour
   {
   
    public float speed = 10f;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
   
    void Update()
    {
        float straffe = Input.GetAxis("Horizontal") * speed;
        float translation = Input.GetAxis("Vertical") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;  
    }
   }
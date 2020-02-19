using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murDeplacement : MonoBehaviour
{
    [SerializeField] private int spawningTime;
    private Transform murTransform;
    private bool state;
    [SerializeField] private float speed=0.01f;
    //true=mur positionne
    //false=mur non positionne

    
    // Start is called before the first frame update
    private void Awake()
    {

        murTransform = transform;
        StartCoroutine(routine: DoDeplaceMur());

    }
    private void Update()
    {
        if (state == true)
        {
            murTransform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
        }
        else
        {
            murTransform.Translate(Vector3.down * Time.deltaTime * speed, Space.Self);
        }
    }

    private IEnumerator DoDeplaceMur()
    {
       while (true)
     {
       yield return new WaitForSeconds(spawningTime);
            if (state == true)
            {
                state = false;
            }
            else
            {
                state = true;
            }

    }
    }
}

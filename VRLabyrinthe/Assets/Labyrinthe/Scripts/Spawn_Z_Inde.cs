using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Z_Inde : MonoBehaviour
{
    public float detRange;
    private float temps = 180f;
    public GameObject zombie = default;
    public GameObject plChar;
    private IEnumerator ref_;
    private bool variable = true;

    public void Start () {
        plChar = GameObject.FindGameObjectWithTag("Player");
        ref_ = Spawn_Zombie(temps);
    }
 
    public void Update () {
        
        if(variable)
        {
            if((plChar.transform.position - transform.position).magnitude > 2 && (plChar.transform.position - transform.position).magnitude < detRange)
            {
                Instantiate(zombie, new Vector3(transform.position.x,5f,transform.position.z), Quaternion.Euler(0f,0f,0f));
                StartCoroutine(ref_);
                variable = false;
            }
        }
    } 
    private IEnumerator Spawn_Zombie(float duree)
    {
        yield return new WaitForSeconds(duree);
        variable = true;
    }
}

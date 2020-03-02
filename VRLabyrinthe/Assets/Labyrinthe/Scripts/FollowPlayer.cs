using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float detRange;
    public float speed;
    private float temps = 180f;
 
    public GameObject plChar;
    private IEnumerator coroutine;
    private Vector3 monoTransform;

    public GameObject zone_invisible;

    private Collision colli;

    public void Start () {
        plChar = GameObject.FindGameObjectWithTag("Player");
        monoTransform = transform.position;
        coroutine = Despawn(temps);
        StartCoroutine(coroutine);
    }
 
    public void Update () {
        if((plChar.transform.position - transform.position).magnitude > 1 && (plChar.transform.position - transform.position).magnitude < detRange)
        {
            transform.LookAt(plChar.transform.position);
            transform.Translate(Vector3.forward * speed);
        }
    } 
    private IEnumerator Despawn(float duree)
    {
        while (true)
        {
            yield return new WaitForSeconds(duree);
            transform.position = monoTransform;
        }
    }
}

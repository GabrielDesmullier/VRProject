using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] private GameObject cibles = default;
    public float vitesse_flux = 0.5f;
    private Transform monoTransform;
    // Start is called before the first frame update
    private IEnumerator periode;

    void Start()
    {
        monoTransform = transform;
        periode = Spawn_(vitesse_flux);
        StartCoroutine(periode);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator Spawn_(float duree)
    {
        while (true)
        {
            yield return new WaitForSeconds(duree);
            Instantiate(cibles, monoTransform.position, Quaternion.identity);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrown : MonoBehaviour
{
    public GameObject crown = default;
    private GameObject _a = default;
    private bool _timer = true;
    private Vector3 _pos = default;
    public int x_min = -100;
    public int x_max = 100;
    public int y_min = -100;
    public int y_max = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        _pos = new Vector3(Random.Range(x_min, x_max), 0.5f, Random.Range(y_min, y_max));
        Instantiate(crown, _pos, Quaternion.identity);
        StartCoroutine(Spawn_Crown(10f));

    }

    // Update is called once per frame
    void Update()
    {
        if(_timer == false)
        {
            _a = GameObject.FindGameObjectWithTag("Crown");
            Destroy(_a);
            
        }
    }
    private IEnumerator Spawn_Crown(float duree)
    {
        yield return new WaitForSeconds(duree);
        _timer = false;
        StartCoroutine(Respawn_Key(20f));
    }
    private IEnumerator Respawn_Key(float duree)
    {
        yield return new WaitForSeconds(duree);
        _timer = true;
        _pos = new Vector3(Random.Range(x_min, x_min), 0.5f, Random.Range(y_min, y_max));
        Instantiate(crown, _pos, Quaternion.identity);
        StartCoroutine(Spawn_Crown(20f));
    }
}

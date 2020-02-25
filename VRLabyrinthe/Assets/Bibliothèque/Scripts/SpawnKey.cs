using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpawnKey : MonoBehaviour
{
    public KeyList keylist;
    private GameObject[] _a = default;
    private Vector3 _pos1;
    private Vector3 _pos2;
    private Vector3 _pos3;
    private Vector3 _pos4;
    private Vector3 _pos5;
    private GameObject _key;
    private GameObject _key2;
    private GameObject _key3;
    private GameObject _key4;
    private GameObject _key5;
    private bool _boucle = true;
    private bool _timer = true;
    public int x_min = -100;
    public int x_max = 100;
    public int y_min = -100;
    public int y_max = 100;


    private void Start()
    {
        _pos1 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos2 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos3 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos4 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos5 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        keylist.liste[0].key.transform.GetComponent<MeshRenderer>().material = keylist.liste[0].color;
        keylist.liste[1].key.transform.GetComponent<MeshRenderer>().material = keylist.liste[1].color;
        keylist.liste[2].key.transform.GetComponent<MeshRenderer>().material = keylist.liste[2].color;
        keylist.liste[3].key.transform.GetComponent<MeshRenderer>().material = keylist.liste[3].color;
        keylist.liste[4].key.transform.GetComponent<MeshRenderer>().material = keylist.liste[4].color;
    
        _key = Instantiate(keylist.liste[0].key, _pos1, Quaternion.identity);
        _key2 = Instantiate(keylist.liste[1].key, _pos2, Quaternion.identity);
        _key3 = Instantiate(keylist.liste[2].key, _pos3, Quaternion.identity);
        _key4 = Instantiate(keylist.liste[3].key, _pos4, Quaternion.identity);
        _key5 = Instantiate(keylist.liste[4].key, _pos5, Quaternion.identity);
        SetNumberKeys();
        StartCoroutine(Spawn_Key(20f));
        
    }
    private void Update()
    {
        if(_timer == false)
        {
            _a = GameObject.FindGameObjectsWithTag("Key");
            foreach(GameObject o in _a)
            {
                Destroy(o);
            }

            Destroy(GameObject.FindGameObjectWithTag("Key_D"));
        }
    }
    
    private IEnumerator Spawn_Key(float duree)
    {
        yield return new WaitForSeconds(duree);
        _timer = false;
        StartCoroutine(Respawn_Key(10f));
    }
    private IEnumerator Respawn_Key(float duree)
    {
        yield return new WaitForSeconds(duree);
        _timer = true;
        _pos1 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos2 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos3 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos4 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _pos5 = new Vector3(Random.Range(x_min, x_max), 1f, Random.Range(y_min, y_max));
        _key = Instantiate(keylist.liste[0].key, _pos1, Quaternion.identity);
        _key2 = Instantiate(keylist.liste[1].key, _pos2, Quaternion.identity);
        _key3 = Instantiate(keylist.liste[2].key, _pos3, Quaternion.identity);
        _key4 = Instantiate(keylist.liste[3].key, _pos4, Quaternion.identity);
        _key5 = Instantiate(keylist.liste[4].key, _pos5, Quaternion.identity);
        SetNumberKeys();
        StartCoroutine(Spawn_Key(20f));
    }
    private void SetNumberKeys()
    {
        while(_boucle == true)
        {
            keylist.liste[0].number = Random.Range(1, 6);
            keylist.liste[1].number = Random.Range(1, 6);
            if(keylist.liste[0].number != keylist.liste[1].number)
            {
                keylist.liste[2].number = Random.Range(1,6);
                if(keylist.liste[2].number != keylist.liste[0].number)
                {
                    keylist.liste[3].number = Random.Range(1,6);
                    if(keylist.liste[3].number != keylist.liste[0].number)
                    {
                        keylist.liste[4].number = Random.Range(1,6);
                        if(keylist.liste[4].number != keylist.liste[0].number)
                        {
                            _boucle = false;
                            _key.GetComponent<collision>().SetText().text = keylist.liste[0].number.ToString();
                            _key2.GetComponent<collision>().SetText().text = keylist.liste[1].number.ToString();
                            _key3.GetComponent<collision>().SetText().text = keylist.liste[2].number.ToString();
                            _key4.GetComponent<collision>().SetText().text = keylist.liste[3].number.ToString();
                            _key5.GetComponent<collision>().SetText().text = keylist.liste[4].number.ToString();

                        }
                    }
                }
            }
        }
    }
}

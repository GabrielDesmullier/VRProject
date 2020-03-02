using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class RecupKey : MonoBehaviour
{
    private int _nbrGoldKey = 0;
    [SerializeField] public TextMeshProUGUI recupOk = default;
    [SerializeField] public TextMeshProUGUI nbrkey = default;
    [SerializeField] public KeyList keyList = default;
    private bool a = true;
    private bool b = false;

    private List<String> _listNumber = new List<String>(){"a","b","c","d","e"};
    // Start is called before the first frame update
    private void Start()
    {
        recupOk.text = "";
        nbrkey.text = "";
    }
    
    private void Update()
    {
        nbrkey.text = _nbrGoldKey.ToString();
        if(a == false)
        {
            recupOk.text = "Vous avez les 5 clés, dirigez vous vers la sortie !";
            SceneManager.LoadScene("galerieRoi");
            
        }
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            Debug.Log("Distance objet :" + hit.distance);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.magenta);
            Debug.Log("Did not Hit");
        }

        if (b == true)
        {
            Debug.Log("DEUX CLEFS DE MEME CHIFFRE !");
            Debug.Log("DEUX CLEFS DE MEME CHIFFRE !");
            b = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Key_D"))
        {
            
            _listNumber[_nbrGoldKey] = collision.gameObject.GetComponent<collision>().SetText().text;
            _nbrGoldKey++;
            Debug.Log(_nbrGoldKey);
            if (_listNumber[0] == _listNumber[1] || _listNumber[0] == _listNumber[2] ||
                _listNumber[0] == _listNumber[2] || _listNumber[0] == _listNumber[3] ||
                _listNumber[0] == _listNumber[4] || _listNumber[1] == _listNumber[2] ||
                _listNumber[1] == _listNumber[3] || _listNumber[1] == _listNumber[4] ||
                _listNumber[2] == _listNumber[3] || _listNumber[2] == _listNumber[4] ||
                _listNumber[3] == _listNumber[4])
            {
                
                b = true;
                _listNumber.RemoveAt(_nbrGoldKey-1);
                _nbrGoldKey--;
                
            }
            if(_nbrGoldKey == 5)
            {
                a = false;
            }
        }
    }

    private IEnumerator Attente(float duree)
    {
        yield return new WaitForSeconds(duree);
    }
}

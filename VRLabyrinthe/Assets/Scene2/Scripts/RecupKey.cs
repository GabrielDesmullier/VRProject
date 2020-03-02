using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RecupKey : MonoBehaviour
{
    private int _nbrGoldKey = 0;
    [SerializeField] private TextMeshProUGUI recup_ok = default;
    [SerializeField] private TextMeshProUGUI nbrkey = default;
    [SerializeField] private TextMeshProUGUI distanceText = default;
    [SerializeField] private KeyList keyList = default;
    private bool a = true;

    private List<String> _listNumber = new List<String>(){"a","b","c","d","e"};
    // Start is called before the first frame update
    private void Start()
    {
        recup_ok.text = "";
        nbrkey.text = "0";
    }
    
    private void Update()
    {
        nbrkey.text = _nbrGoldKey.ToString();
        if(a == false)
        {
            recup_ok.text = "Vous avez les 5 clés!";
            SceneManager.LoadSceneAsync("galerieRoi");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Did Hit");
                Debug.Log("Distance objet :" + hit.distance);
                distanceText.text = hit.distance.ToString();
            }
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
                _listNumber.RemoveAt(_nbrGoldKey-1);
                _nbrGoldKey--;
                recup_ok.text = "Vous avez 2 clés avec le même chiffre, veuillez recommencer !";
                StartCoroutine(Attente(3f));
                recup_ok.text = "";
                
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private Vector3 base_ref;
    private GameObject[] _a = default;

    public TextMeshProUGUI affichage_pdv = default;
    public TextMeshProUGUI mort = default;

    public TextMeshProUGUI mort2 = default;

    private int pdv;
    private IEnumerator duree_invinsible;

    public GameObject fantome = default;
    private float x;
    private float z;

    public void Start()
    {
        mort.text = "";
        mort2.text = "";
        pdv = 100;
        base_ref = new Vector3(55f,10f,45f);
        affichage_pdv.text = pdv.ToString();
        duree_invinsible = Attente(10f);
    }

    public void Update()
    {
        affichage_pdv.text = pdv.ToString();
        if(mort.text == "Game Over"){
            transform.position = base_ref;
            if (Input.GetKeyDown(KeyCode.R))
            {
                mort.text = "";
                mort2.text = "";
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Terrain")
        {
            Debug.Log(collision.gameObject.name);
            if(collision.gameObject.tag == "Porte" || collision.gameObject.tag == "Fantome")
            {
                Debug.Log("Perte de PV");
                pdv -= 20;
                if(pdv == 0)
                {
                    this.transform.position = base_ref;
                    mort.text = "Game Over";
                    mort2.text = "Restart (Press R)";
                    pdv = 100;
                }
            }
            if(collision.gameObject.tag == "Checkpoint")
            {
                base_ref = transform.position;
            }   
            if(collision.gameObject.tag == "Life")
            {
                pdv += 20;
            }
            if(collision.gameObject.tag == "Invinsible")
            {
                _a = GameObject.FindGameObjectsWithTag("Fantome");
                foreach (GameObject o in _a)
                {
                    Destroy(o);
                }
            }
        }
    }
    private IEnumerator Attente(float duree)
    {
        yield return new WaitForSeconds(duree);
        Debug.Log("Fin attente");
    }
}



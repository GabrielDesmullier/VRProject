using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class life : MonoBehaviour

{
    private Vector3 base_ref;
    private int lifeLevel;
    private bool isVisible;
    public TextMeshProUGUI mort = default;
    public TextMeshProUGUI mort2 = default;
    public TextMeshProUGUI affichae_pdv = default;
    
    void Start()
    {
        base_ref = new Vector3(46,2, 16);
        mort.text = "";
        mort2.text = "";
    }
    // Start is called before the first frame update
    public bool getIsVisible()
    {
        return isVisible;
    }

    public void changeVisible()
    {
        if (isVisible == true)
        {
            isVisible = false;
        }
        else
        {
            isVisible = true;
        } 
    }
    
    public void setLifeLevel(int zdhazuhd)
    {
        lifeLevel = zdhazuhd;
    }

    public int getLifeLevel()
    {
        return lifeLevel;
    }
    private void Awake()
    {
        lifeLevel = 100;
        isVisible = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log(message: collision.gameObject.name);
        if (collision.gameObject.CompareTag("ghost"))
        {
            lifeLevel = lifeLevel - 20;
            Debug.Log(message: collision.gameObject.name);
            if(lifeLevel <= 0)
            {
                transform.position = base_ref;
                mort.text = "Game Over";
                mort2.text = "Restart (Press R)";
                lifeLevel = 100;
            }
        }
        if (collision.gameObject.CompareTag("movingHedge"))
        {
            
            lifeLevel = lifeLevel-30;
            Debug.Log(message: collision.gameObject.name);
            if(lifeLevel <= 0)
            {
                this.transform.position = base_ref;
                mort.text = "Game Over";
                mort2.text = "Restart (Press R)";
                lifeLevel = 100;
            }
        }
        if(collision.gameObject.CompareTag("Checkpoint"))
        {
            base_ref = transform.position;
        }



    }
    // Update is called once per frame
    void Update()
    {
        affichae_pdv.text = lifeLevel.ToString();
        if(mort.text == "Game Over"){
            transform.position = base_ref;
            if (Input.GetKeyDown(KeyCode.R))
            {
                mort.text = "";
                mort2.text = "";
            }
        }
    }
}

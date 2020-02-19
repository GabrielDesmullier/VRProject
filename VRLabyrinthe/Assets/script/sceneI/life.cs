using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour

{
    private int lifeLevel;
    private bool isVisible;
    
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
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log(message: collision.gameObject.name);
        if (collision.gameObject.tag == "ghost")
        {
            lifeLevel = lifeLevel - 50;
            Debug.Log(message: collision.gameObject.name);
        }
        if (collision.gameObject.tag == "movingHedge")
        {
            
            lifeLevel = lifeLevel-30;
            Debug.Log(message: collision.gameObject.name);


        }



    }
    // Update is called once per frame
    void Update()
    {
        if (lifeLevel <= 0)
        {
            Debug.Log(message: "death");
            Destroy(gameObject);
        }
    }
}

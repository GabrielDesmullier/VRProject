using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostControlleur : MonoBehaviour
{
    private Transform ghostTransform;
    private GameObject player;
    private Transform playerTransform;
    private float distance;
    private bool active;


    [SerializeField] private float speed=10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform;
        
    }

    public void setPlayer(GameObject playerObject)
    {
        player = playerObject;
        

    }
    private void Awake()
    {
        ghostTransform = transform;
        
        StartCoroutine(routine: DestroyGhost());
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(ghostTransform.position, playerTransform.position);
        
        if ((distance < 10) && (player.GetComponent<life>().getIsVisible() == true)){//les distances ne sont pas celles de l'énoncé pour coller à l'échelle du labyrinthe et au jeu
            
            active = true;
            ghostTransform.LookAt(playerTransform.position);
            ghostTransform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            StopCoroutine(routine: DestroyGhost());

        }
        else
        {
            active = false;
            
        }
    }
    private IEnumerator DestroyGhost()
    {
        while (true)
        {
            if (active == false)
            {
                yield return new WaitForSeconds(180);
                Destroy(gameObject);
            }

        }
   }
}

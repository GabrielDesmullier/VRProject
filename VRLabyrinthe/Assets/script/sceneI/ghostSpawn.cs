using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSpawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform spawnerTransform;
    private Transform playerTransform;
    [SerializeField] private GameObject ghost;
    private float distance;
    // Start is called before the first frame update

    private void Awake()
    {
        spawnerTransform = transform;
        playerTransform = player.transform;
        StartCoroutine(routine: InvoqueGhost());
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator InvoqueGhost()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            distance = Vector3.Distance(spawnerTransform.position, playerTransform.position);


            if (distance < 15)//les distances ne sont pas celles de l'énoncé pour coller à l'échelle du labyrinthe et au jeu

            {
                GameObject oneGhost=Instantiate(ghost, spawnerTransform.position, Quaternion.identity, spawnerTransform);
                oneGhost.GetComponent<ghostControlleur>().setPlayer(player);
                Debug.Log(message: "ghost!");
            }
        }
    }
}

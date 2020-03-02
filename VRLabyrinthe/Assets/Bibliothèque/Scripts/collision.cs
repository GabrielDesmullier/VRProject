using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collision : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI affichageNum = default;

    public TextMeshProUGUI SetText()
    {
        return affichageNum;
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name);
            Destroy(gameObject);

        }
    }
}

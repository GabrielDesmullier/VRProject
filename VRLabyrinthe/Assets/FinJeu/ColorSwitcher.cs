using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorSwitcher : MonoBehaviour
{
    [SerializeField] private Image backgroundImage = default;
    private bool isToggled = false;
    private Coroutine a;

    public void Start()
    {
        StartCoroutine(Couleurs());
    }

    private IEnumerator Couleurs()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            backgroundImage.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            backgroundImage.color = Color.blue;
            yield return new WaitForSeconds(0.2f);
            backgroundImage.color = Color.green;
            yield return new WaitForSeconds(0.2f);            
            backgroundImage.color = Color.magenta;
            yield return new WaitForSeconds(0.2f);
            backgroundImage.color = Color.grey;

        }
    }
}

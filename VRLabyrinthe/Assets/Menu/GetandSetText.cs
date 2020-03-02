using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GetandSetText : MonoBehaviour
{
    public TMP_InputField name_register;

    public TMP_InputField surname_register;

    public TMP_InputField password_register;
    public TMP_InputField name_login;
    public TMP_InputField password_login;
    private string password_memory;
    private string name_memory;
    private string surname_memory;

    public TextMeshProUGUI affichage_nom;
    // Start is called before the first frame update
    public void setget()
    {
        affichage_nom.text = "Welcome " + name_register.text + " " + surname_register.text;
        password_memory = password_register.text;
        name_memory = name_register.text;
        surname_memory = surname_register.text;
        StartCoroutine(Attente(2f));
        SceneManager.LoadScene("Labyrinthe");

    }
    
    public void getset()
    {
        if (password_login.text == password_memory && name_login.text == name_memory)
        {
            affichage_nom.text = "Welcome back " + name_login.text + " " + surname_memory;
            StartCoroutine(Attente(2f));
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            affichage_nom.text = "Mauvais identifiants, réessayez !";
        }

    }

    public string GetPassword()
    {
        return password_memory;
    }
    public string GetName()
    {
        return name_memory;
    }
    public string GetSurname()
    {
        return surname_memory;
    }
    private IEnumerator Attente(float duree)
    {
        yield return new WaitForSeconds(duree);
    }
}

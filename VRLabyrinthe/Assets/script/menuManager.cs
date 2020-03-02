using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject login = default;
    [SerializeField] private GameObject register = default;
    [SerializeField] private GameObject gameMenu = default;
    [SerializeField] private TextMeshProUGUI erreur;
    //de manière brute
    [SerializeField] private TMP_InputField newLogin;
    [SerializeField] private TMP_InputField newPassword;
    [SerializeField] private TMP_InputField newFirstName;
    [SerializeField] private TMP_InputField newLastName;
    [SerializeField] private TMP_InputField newEMail;

    [SerializeField] private TMP_InputField currentLogin;
    [SerializeField] private TMP_InputField currentPassword;



    private DB_Manager databaseconnection;

    public void Awake()
    {
        Cursor.visible = true;
        databaseconnection = GetComponent<DB_Manager>();
    }
    public void loadLogin()
    {
        login.SetActive(true);
        register.SetActive(false);
    }

    public void registerAction()
    {
        if (databaseconnection.checkState() != "Closed") //verification connection
        {
            databaseconnection.SendData2DataBase(newLogin.text, newPassword.text, newFirstName.text, newLastName.text, newEMail.text);//envoi du formulaire
            erreur.text = "register OK";
        }
        else
        {
            erreur.text = "connection problem";
        }
    }

    public void loadRegister()
    {
        register.SetActive(true);
        login.SetActive(false);
    }

    public void loadgameMenu()
    {
        if (databaseconnection.checkState() != "Closed")//vérification de la connection
        {
            if (databaseconnection.ReadPasswordFromDataBase(currentLogin.text) == currentPassword.text)//vérification mot de passe
            {
                gameMenu.SetActive(true);
                login.SetActive(false);
                erreur.text = "login!";
            }
            else
            {
                erreur.text = "password is wrong";
            }
        }
        else
        {
            erreur.text = "connection problem";
            if ((currentLogin.text == "debug") && (currentPassword.text == "debug"))//debuggage en cas de panne du service
            {
                gameMenu.SetActive(true);
                login.SetActive(false);
                erreur.text = "login!";
            }

        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadScene1()
    {
        SceneManager.LoadScene("Labyrinthe");
    }

    public void loadScene2()
    {
        SceneManager.LoadScene("Bibliothèque");
    }

    public void loadScene3()
    {
        SceneManager.LoadScene("galerieRoi");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}

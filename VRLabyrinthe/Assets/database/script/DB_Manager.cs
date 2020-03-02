using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // pour changer de scène
using MySql.Data.MySqlClient;  // permet d'utilser mysql
using System.Text.RegularExpressions; // permet de verifier si c'est un émail, ou si un caractère spécial est present dans le texte
using UnityEngine.UI; // permet d'utiliser les interfaces UI
using System; // permet d'utilser les try and catch
//
public class DB_Manager : MonoBehaviour
{

    public static DB_Manager instance;
    MySqlConnection sql;
    [Header("PARAMETRE DE CONNEXION")]
    public string host;
    public string database;
    public string username;
    public string password;

    private void Awake()
    {
        if (instance !=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ConnectDataBase(); // pour connecter à la base de données
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sql.State);
    }

    public string checkState()
    {
        return sql.State.ToString();
    }
    void ConnectDataBase()
    {
        string sql_connect = "SERVER =" + host + ";database = " + database + ";User ID =" + username + ";Password = " + password + ";Pooling =true; Charset=utf8"; // commande 
        try
        {
            sql = new MySqlConnection(sql_connect);
            sql.Open();
        }catch(Exception ex)
        {
            Debug.Log(ex.ToString()); // en cas de problème, il renvoie le message d'erreur
        }
    }
   
    public void SendData2DataBase(string login,string password,string firstname,string lastname, string email) // ecrire dans la base de données
    {
        string sql_connect = "INSERT INTO `user` (`login`, `password`, `firstname`, `lastname`, `email`) VALUES('"+login+"', '"+password+"', '"+firstname+"', '"+lastname+"', '"+email+"')";
        MySqlCommand sql_ = new MySqlCommand(sql_connect,sql);  // preparer la commande
        try
        {
            sql_.ExecuteReader(); // ecrire dans la base de données
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString()); // en cas de problème, il renvoie le message d'erreur
        }
    }
    public string ReadPasswordFromDataBase(string login) // rechercher un nom
    {
        try
        {
            MySqlCommand sql_ = new MySqlCommand("SELECT password FROM `user` WHERE `nom`='" + login + "'", sql);
            MySqlDataReader MyReader = sql_.ExecuteReader(); // lire la base de données
            string data = null;

            while (MyReader.Read())
            {
                data = MyReader.GetString(0);

                if (data != null)
                {
                   
                    MyReader.Close();
                   
                }
            }
            MyReader.Close();
            return data;

        }
        catch (Exception Ex)
        {
            Debug.Log(Ex.ToString());
            return null;
        }
 
    }
    
   

}

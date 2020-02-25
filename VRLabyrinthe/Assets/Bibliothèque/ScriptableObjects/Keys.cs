using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Key", menuName = "Key")]
public class Keys : ScriptableObject
{
    public Material color;
    public GameObject key;
    public int number;
}

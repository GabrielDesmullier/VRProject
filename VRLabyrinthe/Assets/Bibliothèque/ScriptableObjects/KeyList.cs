using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List of Keys", menuName = "Key List")]
public class KeyList : ScriptableObject
{
    public List<Keys> liste = new List<Keys>();
}

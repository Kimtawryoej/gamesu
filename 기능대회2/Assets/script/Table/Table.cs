using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
[System.Serializable]
public class Table : ScriptableObject
{
    public float scroe;
    public float Time;
    public string Name;
    public List<string> saveName = new List<string>();
    public List<float> saveScore = new List<float>();
    public List<GameObject> gameObject = new List<GameObject>();
}

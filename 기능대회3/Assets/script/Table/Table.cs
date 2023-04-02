using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu]
public class Table : ScriptableObject
{
    public float Score;
    public string Name;
    public List<float> SaveScore;
    public List<string> SaveName;
    public float Time;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHpManager : MonoBehaviour
{
    public static MonsterHpManager instance;
    public float normal1=5, normal2 = 8, boss = 30, meteor = 1;

    private void Awake()
    {
        instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletone
{
    public static singletone Instance;
    public float score = 0;
    void Start()
    {
        Instance = this;
    }
}

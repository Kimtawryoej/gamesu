using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Monster Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

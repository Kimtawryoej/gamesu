using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance ;

    void Awake()
    {

        Instance = this as T;
    }

}

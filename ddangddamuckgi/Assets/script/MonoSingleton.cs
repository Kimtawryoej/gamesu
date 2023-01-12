using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static  T instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this as T;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

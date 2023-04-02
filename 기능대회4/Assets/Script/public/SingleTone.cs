using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTone<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;
    public virtual void Awake()
    {
        Instance = this as T;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

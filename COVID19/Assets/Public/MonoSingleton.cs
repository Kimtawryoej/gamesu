using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour //클래스만 들어오도록
{
    public static T Instance;
    void Awake()
    {
        Instance = this as T; //this를 T로 바꿔줌
    }

   
}

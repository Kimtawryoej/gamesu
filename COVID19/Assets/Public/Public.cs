using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Public : MonoBehaviour
{
    public static Public Instance;
    public Data datas;

    // Start is called before the first frame update
     void Awake()
    {
     var obj = FindObjectsOfType<Public>();
        if(obj.Length == 1)
        {
            
          DontDestroyOnLoad(gameObject);// 씬으로 넘어갈때 모든 이 스크립트안에 있는 정보를 삭제하지 않고 가져간다.
        }
        else
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class Data
{

    public int hp = 15;
    public int leavel = 1;
    public int pain = 5;
    public int[] score = new int[4];

}
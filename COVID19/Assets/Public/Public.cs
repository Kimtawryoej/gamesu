using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public : MonoBehaviour
{
    public static Public Instance;
    public float hp = 15;
    public int leavel = 1;
    public int pain = 5;
    public int score = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        
        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬으로 넘어갈때 모든 이 스크립트안에 있는 정보를 삭제하지 않고 가져간다.
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

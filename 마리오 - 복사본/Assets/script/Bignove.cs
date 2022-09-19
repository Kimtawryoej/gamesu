using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bignove : HeadBlock
{
    GameObject mari;


    public float jumpPower = 8;
    Rigidbody2D rid;
    Animator ani;

    private void Start()
    {
        mari = GameObject.Find("mario");
        rid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    public override void Execute() //크기 키우는 함수
    {
        mari.transform.localScale = new Vector3 //함수로 만들면 안됨new Vector() 이렇게 함수는 계산을 못함
        (mari.transform.localScale.x + 4,
        mari.transform.localScale.y + 4,
        mari.transform.localScale.z + 4);
    }

    

    
}

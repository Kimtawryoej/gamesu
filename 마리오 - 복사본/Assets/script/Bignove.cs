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
    public override void Execute() //ũ�� Ű��� �Լ�
    {
        mari.transform.localScale = new Vector3 //�Լ��� ����� �ȵ�new Vector() �̷��� �Լ��� ����� ����
        (mari.transform.localScale.x + 4,
        mari.transform.localScale.y + 4,
        mari.transform.localScale.z + 4);
    }

    

    
}

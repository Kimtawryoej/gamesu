using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager instance;
    public float PlayerAttack = 1, NormalMonsterAttack = 1, BossAttack = 2,Meteor =1,Raser = 5;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

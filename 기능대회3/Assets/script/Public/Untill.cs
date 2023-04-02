using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Untill : MonoBehaviour
{

    public float Hp;
    public float Fuel;
    public float Attack;

    public void FuelManager(float MaxFuel)
    {
        Fuel = Mathf.Clamp(Fuel - Time.deltaTime, 0, MaxFuel);
        //Debug.Log(Fuel);
        if (Fuel == 0)
            Die();
    }
    public void HpManager(float MaxHp)
    {
        //Debug.Log(Hp);
        Hp = Mathf.Clamp(Hp - Attack, 0, MaxHp);
        //Debug.Log(Hp);
        if (Hp == 0)
            Die();
    }
    public virtual void Die() { }
}

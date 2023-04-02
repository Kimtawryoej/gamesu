using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Unit : MonoBehaviour
{
    float hp;
   public  float Hp { get => hp; set => hp = value; }
    float fuel;
    public float Fuel { get => fuel; set => fuel = value; }
    float attack;
    public float Attack { get=>attack; set=>attack = value; }

    public void FuelManager(float MaxFuel)
    {
        fuel = Mathf.Clamp(fuel -= Time.deltaTime, 0, MaxFuel);
        if (fuel == 0)
            DieManager();
    }
    public void HpManager(float MaxHp)
    {
        hp = Mathf.Clamp(hp += Attack, 0, MaxHp);
        if (hp <= 0)
            DieManager();
    }
    public virtual void DieManager() { }
}

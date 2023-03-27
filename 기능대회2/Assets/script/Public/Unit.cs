using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { player, Monster }
public class Unit : SingleTone<Unit>
{
    [field: SerializeField] public Type type { get; protected set; }
    public float Hp;
    public float MaxHp;
    public float Fuel;
    
     
    public float fuel(float MaxFuel)
    {
        Fuel = Mathf.Clamp(Fuel -= Time.deltaTime, 0, MaxFuel);
        //Debug.Log(Fuel);
        if (Fuel == 0)
            DIE();
        return Fuel;
    }
    public void HpManager(float Attack)
    {
        Hp = Mathf.Clamp(Hp - Attack, 0, MaxHp);
        Debug.Log(Hp);
        if (Hp == 0)
            DIE();
    }
    virtual public void DIE() { }
}

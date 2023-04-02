using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : SingleTone<Item>
{
    public GameObject[] ObjectITEMs = new GameObject[4]; 
    public Dictionary<string, Action> ITEMs = new Dictionary<string, Action>();
    public List<string> PreITEMS; 

    void Start()
    {
        Action LvUp = () => { Player.Instance.LvGet = Mathf.Clamp(Player.Instance.LvGet += 1, 1, 5); };
        Action Hp = () => { Player.Instance.Hp = 150; };
        Action NeverDie = () => { StartCoroutine(HpUp()); };
        Action Fuel = () => { Player.Instance.Fuel = 60;};
        ITEMs = new Dictionary<string, Action>
        {
            {"공격업",LvUp},
            {"내구도수리",Hp},
            {"무적",NeverDie},
            {"연료회복",Fuel}
        };
    }

    IEnumerator HpUp()
    {
        float time = 0;
        float stateHp = Player.Instance.Hp;

        while (time < 3)
        {
            time += Time.deltaTime;
            Player.Instance.Hp = stateHp;
            yield return null;
        }
        time = 0;
    }
}

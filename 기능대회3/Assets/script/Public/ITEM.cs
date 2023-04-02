using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM : MonoBehaviour
{
    public static ITEM Instance;
    public Dictionary<string, Action> ITEMS = new Dictionary<string, Action>();
    public GameObject[] items;
    float time;
    public List<string> Saveitems;
    private void Start()
    {
        Instance = this;
        Action Lv = () => { Scrpt.Lv = Mathf.Clamp(Scrpt.Lv+=1, 1, 4); Debug.Log("레벨업"); };
        Action HP = () => { Scrpt.Instance.Hp = 150; Debug.Log("회복"); };
        Action Fuel = () => { Scrpt.Instance.Fuel = 60; Debug.Log("내구도충전"); };
        Action neverdie = () => { time += 5; StartCoroutine(never()); Debug.Log("무적"); };
        ITEMS = new Dictionary<string, Action>
        {
            {"공격업",Lv},
            {"내구도업",Fuel},
            {"연료업",HP},
            {"무적",neverdie}
        };
    }
    IEnumerator never()
    {
        Scrpt.Instance.neverDie = false;
        yield return new WaitForSeconds(time);
        Scrpt.Instance.neverDie = true;
    }
}

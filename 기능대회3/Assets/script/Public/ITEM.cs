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
        Action Lv = () => { Scrpt.Lv = Mathf.Clamp(Scrpt.Lv+=1, 1, 4); Debug.Log("������"); };
        Action HP = () => { Scrpt.Instance.Hp = 150; Debug.Log("ȸ��"); };
        Action Fuel = () => { Scrpt.Instance.Fuel = 60; Debug.Log("����������"); };
        Action neverdie = () => { time += 5; StartCoroutine(never()); Debug.Log("����"); };
        ITEMS = new Dictionary<string, Action>
        {
            {"���ݾ�",Lv},
            {"��������",Fuel},
            {"�����",HP},
            {"����",neverdie}
        };
    }
    IEnumerator never()
    {
        Scrpt.Instance.neverDie = false;
        yield return new WaitForSeconds(time);
        Scrpt.Instance.neverDie = true;
    }
}

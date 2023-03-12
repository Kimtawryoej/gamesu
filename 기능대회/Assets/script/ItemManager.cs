using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int b;
    public int c = 0;
    public GameObject[] Key = new GameObject[5];
    public Action[] value = new Action[5];
    public static ItemManager Instance { get; private set; }
    public Dictionary<GameObject, Action> items = new Dictionary<GameObject, Action>();
    private void Start()
    {
        Instance = this;

        items = new Dictionary<GameObject, Action>
        {
            {GameObject.FindWithTag("BulletITem"),BulletItem},
            {GameObject.FindWithTag("invincibilityITEM"),invincibility},
            {GameObject.FindWithTag("suriITem"),HPItem},
            {GameObject.FindWithTag("GageITem"),fuel},
            {GameObject.FindWithTag("Coin"),coin}
        };
        foreach (var item in items)
        {
            Key[c] = item.Key;
            value[c] = item.Value;
            c++;
        }
    }
    Action BulletItem = () =>
    {
        if (Player.LV < 3)
        {
            Player.LV++;
        }
        else
        {
            GameManager.coin += 20;
        }
        Debug.Log("아이템총알");
    };

    Action invincibility = () =>
    {
        GameManager.instance.T += 8;
        Debug.Log(GameManager.instance.T);
        
        if(GameManager.instance.COlor)
            GameManager.instance.StartCoroutine(GameManager.instance.TI());

    };


    Action HPItem = () =>
    {
        Debug.Log("회복");
        Player.Instance.HPMANAGER[0] += 3;
    };

    Action fuel = () =>
    {
        Debug.Log("연료");
        Player.Instance.HPMANAGER[1] += 3;
    };

    Action coin = () =>
    {
        GameManager.coin += 20;
    };
}

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
    public static ItemManager Instance { get; private set; }
    public  Action [] items = new Action[5];
    private void Start()
    {
        Instance = this;
        items[0] = BulletItem;
        items[1] = invincibility;
        items[2] = HPItem;
        items[3] = fuel;
        items[4] = coin;
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

using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Skill Instance { get; private set; }
    enum Chance { chance = 5, chance2 = 2 };
    Chance c = Chance.chance;
    Chance c2 = Chance.chance2;
    Dictionary<KeyCode, Action> key = new Dictionary<KeyCode, Action>();
    public float t = 5, t2 = 6, t3 = 5, t4, t5 = 6;
    bool Bool;
    bool Bool2;

    private void Awake()
    {
        Instance = this;
        t3 = 5;
        t5 = 6;
        Bool = true;
        Bool2 = true;
    }
    private void Start()
    {
        Action F = () =>
        {
            if (c > 0 && t3 == 5)
            {
                Player.Instance.HPMANAGER[1] += 3; c -= 1;
                if (Player.Instance.HPMANAGER[1] > HpManager.Instance.MaxTime)
                {
                    Player.Instance.HPMANAGER[1] = HpManager.Instance.MaxTime;
                }
            }
        };
        Action G = () =>
        {
            if (c2 > 0 && t5 == 6)
            {
            c2 -= 1;
            Boom.instance.gameObject.SetActive(true);
        }
    };
    key = new Dictionary<KeyCode, Action>
        {
            {KeyCode.F,F},
            { KeyCode.G,G}
        };
    }
    void Update()
{
    if (Input.anyKey)
    {
        foreach (var key in key)
        {
            if (Input.GetKeyDown(key.Key))
            {
                key.Value();
            }
        }
    }
    if (Input.GetKeyDown(KeyCode.F) && Bool)
    {
        Bool = false;
        StartCoroutine(coo2l(5));
    }
    else if (Input.GetKeyDown(KeyCode.G) && Bool2)
    {
        Bool2 = false;
        StartCoroutine(coo3l(6));
    }
    IEnumerator coo2l(float value)
    {
        t3 = value;
        while (t3 > 0)
        {
            t3 -= Time.deltaTime;
            yield return null;
        }
        t3 = value;
        Bool = true;
    }
    IEnumerator coo3l(float value)
    {
        t5 = value;
        while (t5 > 0)
        {
            t5 -= Time.deltaTime;
            yield return null;
        }
        t5 = value;
        Bool2 = true;
    }
}
}


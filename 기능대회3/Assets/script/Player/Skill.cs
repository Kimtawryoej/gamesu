using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Skill Instance { get; private set; }
    Dictionary<KeyCode, Action> skills = new Dictionary<KeyCode, Action>();
    public float CoolTime1 = 10;
    public float CoolTime2 = 10;
    int cool = 10;
    int cool2 = 3;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Action skill1 = () =>
        {

            if (cool > 0 && CoolTime1 >= 10)
            {
                Scrpt.Instance.Hp = 150;
                cool--;
                Debug.Log("È¸º¹");
                StartCoroutine(Cool1(CoolTime1));
            }
        };
        Action skill2 = () =>
        {
            int cool2 = 3;
            if (cool2 > 0 && CoolTime2 >= 10)
            {
                Debug.Log("ÆøÅº");
                PlayerskillBoom.Instance.gameObject.SetActive(true);
                cool--;
                StartCoroutine(Cool2(CoolTime2));
            }
        };
        skills = new Dictionary<KeyCode, Action>
        {
            {KeyCode.F,skill1},
            {KeyCode.G,skill2},
        };
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            foreach (var item in skills)
            {
                //Debug.Log(item.Key);
                if (Input.GetKey(item.Key))
                {
                    item.Value();
                }
            }
        }
    }

    IEnumerator Cool1(float cool)
    {

        while (CoolTime1 > 0)
        {
            CoolTime1 -= Time.deltaTime;
            yield return null;
        }
        CoolTime1 = cool;
    }

    IEnumerator Cool2(float cool)
    {

        while (CoolTime1 > 0)
        {
            CoolTime2 -= Time.deltaTime;
            yield return null;
        }
        CoolTime2 = cool;
    }
}

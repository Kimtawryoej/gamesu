using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : SingleTone<ItemManager>
{
    public List<GameObject> Item = new List<GameObject>();
    public List<GameObject> ITEM = new List<GameObject>();
    public Text [] ITEMUi = new Text[4];
    float hp;
    public Dictionary<string, Action> Items = new Dictionary<string, Action>();
    bool Bool = true;
    private void Start()
    {
        Action item1 = () => { Player.instance.LevelUp(); Debug.Log("������"); };
        Action item2 = () => { StartCoroutine(Item2()); Debug.Log("����"); };
        Action item3 = () => { Player.instance.Fuel = 60; Debug.Log("����"); };
        Action item4 = () => { Hp(); Debug.Log("ȸ��"); };
        Items = new Dictionary<string, Action>
        {
            {"������",item1},
            {"����������",item2},
            {"����������",item3},
            {"���������",item4}
        };
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && ITEM.Count > 0 && Bool)
        {
            Bool = false;
            for(int i =0; i< ITEM.Count; i++)
            {
                Debug.Log(ITEM.Count);
                ITEM[i].transform.position = Player.instance.transform.position;
                Ui.Instance.ITEM.Add(ITEMUi[i]);
            }
                Debug.Log(Ui.Instance.ITEM.Count);
            StartCoroutine(re());
        }

    }
    void Hp()
    {
        hp = Mathf.Clamp(Player.instance.Hp = 150, 0, 150);
    }
    IEnumerator Item2()
    {
        Player.instance.Attack = 0;
        yield return new WaitForSeconds(3);
        Player.instance.Attack = 1;
    }
    IEnumerator re()
    {
        yield return new WaitForSeconds(1);
        Bool = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public static Player Instance { get; private set; }
    float time;
    [SerializeField]
    GameObject Bullet;
    Unit unit = new Unit();
    [SerializeField]
    GameObject[] Savebullet = new GameObject[5];
    [SerializeField]
    List<GameObject> Bullets;
    [SerializeField]
    int Lv;
    public int LvGet { get => Lv; set => Lv = value; }
    public override void DieManager()
    {
        base.DieManager();
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        Instance = this;
        Hp = 150;
        Fuel = 60;
        Attack = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        FuelManager(Fuel);
        BulletShot();
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(-V, 0, H);
        transform.position += dir * 20 * Time.deltaTime;
    }
    void BulletShot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            time += Time.deltaTime;
            if (time > 0.1f)
            {
                Bullets.Clear();
                for (int i = 0; i < Lv; i++)
                {
                    Bullets.Add(Savebullet[i]);
                }
                foreach (GameObject bullet in Bullets)
                {
                    Instantiate(Bullet, bullet.gameObject.transform.position, Quaternion.identity);
                    time = 0;
                }

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        TriggerManager.Instance.CheackGameObject(gameObject);
        TriggerManager.Instance.OnTriggerEnter(other);
        if(other.gameObject.layer == 7)
        {
            foreach(var a in Item.Instance.ITEMs)
            {
                if(a.Key == other.tag )
                {
                    a.Value();
                    Item.Instance.PreITEMS.Add(other.gameObject.tag);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}

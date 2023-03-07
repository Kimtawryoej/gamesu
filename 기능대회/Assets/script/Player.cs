using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public bool True;
    public GameObject Partical;
    public float[] HPMANAGER = new float[3];
    HpManager hpManager = new HpManager();
    Leavel lv = new Leavel();
    public GameObject Bullet;
    public float MaxHp = 10;
    public static Player Instance { get; private set; }
    int speed = 5;
    public float MaxX, MaxY, MinX, MinY;
    float MultiKey;
    float firstKey;
    private void Awake()
    {
        Instance = this;
        hpManager.action(10, 10, 0, 0);
        hpManager.MaxTime = 10;
        hpManager.MaxHp = 10;
    }
    public void Start()
    {
        hpManager.Start();
        hpManager.action(10, 10, 0, 0);



    }
    // Update is called once per frame
    void Update()
    {
        Func<KeyCode, KeyCode, float, float> action = (k1, k2, dir) =>
        {
            if (Input.GetKey(k1))
            {
                dir = -1;
                if (Input.GetKeyDown(k1))
                {
                    MultiKey++;
                }
                if (MultiKey == 1)
                {
                    firstKey = -1;
                }
            }
            if (Input.GetKey(k2))
            {
                dir = 1;
                if (Input.GetKeyDown(k2))
                {
                    MultiKey++;
                }
                if (MultiKey == 1)
                {
                    firstKey = 1;
                }
            }
            if (MultiKey == 2)
            {
                dir = -firstKey;
            }
            if (Input.GetKeyUp(k1) || Input.GetKeyUp(k2))
            {
                MultiKey--;
            }
            if (MultiKey == 0)
            {
                firstKey = 0;
            }

            return dir;

        };

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
        float h = action(KeyCode.LeftArrow, KeyCode.RightArrow, 0);
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v);
        transform.position += dir * speed * Time.deltaTime;
        float x = Mathf.Clamp(transform.position.x, MinX, MaxX);
        float y = Mathf.Clamp(transform.position.y, MinY, MaxY);
        transform.position = new Vector3(x, y);
        hpManager.action(HPMANAGER[0], HPMANAGER[1], 0, 0);
        lv.Update();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //hpManager.OnTriggerEnter2D(collision);
        if (collision.gameObject.layer == 3)
        {
            foreach (var key in TriggerManager.instance.MonsterAttack)
            {
                if (key.Key.gameObject.tag == collision.gameObject.tag)
                {

                    Player.Instance.HPMANAGER[0] -= key.Value;
                    Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90,0,0));
                }
            }
        }
    }

}
public class HpManager : MonoBehaviour
{
    public float MaxHp = 10;
    public float MaxTime;
    public static HpManager Instance;
    public void Start()
    {
        Instance = this;
    }
    public Action<float, float, float, float> action = (hp, fuel, t, t2) =>
    {
        if (hp <= 0 || fuel <= 0)
        {
            Player.Instance.gameObject.SetActive(false);
        }
        if (Player.Instance.True == true)
        {
            hp -= Monster.Instance.MonsterAttack;
            Player.Instance.True = false;
        }
        t += Time.deltaTime;
        t2 = t;
        fuel -= Time.deltaTime * 0.2f;
        Player.Instance.HPMANAGER[0] = hp;
        Player.Instance.HPMANAGER[1] = fuel;


    };

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Monster"))
    //    {
    //        Player.Instance.True = true;
    //        action(10, 10, 0, 0);
    //    }
    //}
}
public class Leavel : MonoBehaviour
{
    /*enum state {}*/
    int Lv = 1;
    public void Update()
    {
        switch (Lv)
        {
            case 1:
                HpManager.Instance.MaxHp = Player.Instance.HPMANAGER[0];
                break;
            case 2:
                Player.Instance.HPMANAGER[0] = HpManager.Instance.MaxHp;
                Player.Instance.HPMANAGER[0] += 2;
                HpManager.Instance.MaxHp = Player.Instance.HPMANAGER[0];
                break;
            case 3:
                Player.Instance.HPMANAGER[0] = HpManager.Instance.MaxHp;
                Player.Instance.HPMANAGER[0] += 2;
                HpManager.Instance.MaxHp = Player.Instance.HPMANAGER[0];
                break;
            case 4:
                Player.Instance.HPMANAGER[0] = HpManager.Instance.MaxHp;
                Player.Instance.HPMANAGER[0] += 2;
                HpManager.Instance.MaxHp = Player.Instance.HPMANAGER[0];
                break;
        }
    }
}

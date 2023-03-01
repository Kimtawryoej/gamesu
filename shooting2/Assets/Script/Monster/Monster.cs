using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : Connection<Monster>
{
    static Vector3 position;
    bool b = true;
    [SerializeField]
    public static float Hp = 5;
    GameObject a;
    // Start is called before the first frame update
    void OnEnable()
    {
        position = transform.position;
        Hp = HpManager.Instance.MonsterHp;
        StopCoroutine(monsterBullet());
        StartCoroutine(monsterBullet());
    }

    IEnumerator monsterBullet()
    {
        WaitForSeconds fix = new WaitForSeconds(4);
        WaitForSeconds wai2 = new WaitForSeconds(3);
        while (true)
        {
            yield return fix;
            if (Boom.Instance.co)
            {
                yield return wai2;
                Boom.Instance.co = false;
            }
            transform.Launch(0, BulletManager.Instance.list[2], 0);
            if (Boom.Instance.co)
            {
                yield return wai2;
                Boom.Instance.co = false;
            }
        }
    }


    public  void OnTriggerEnter2D(Collider2D collision)
    {
        Reach.Instance.OnTriggerEnter2D(collision);
        if (Hp <= 0)
        {
            HpManager.Instance.state = HpManager.State.MonsterState;
        }
    }
}

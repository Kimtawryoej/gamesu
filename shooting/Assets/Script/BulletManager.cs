using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Connection<BulletManager>
{
    public float bulletPower = 0.5f;
    public float bulletPower2 = 2;
    public List<GameObject> list = new List<GameObject>();
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Hp.Instance.MonsterHp--;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Hp.Instance.PlayerHp--;
        }
    }
}

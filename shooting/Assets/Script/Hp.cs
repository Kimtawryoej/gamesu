using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : Connection<Hp>
{
    [HideInInspector]
    public float PlayerHp = 3;
    public float MonsterHp = 3;//float°öÇØ¾ßÇØ¼­ enum¸ø¾¸

    private void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            ObjectPool.Instance.Return(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (Player.Instance.bulletnum == 0)
            {
                MonsterHp -= BulletManager.Instance.bulletPower;
            }
            else if (Player.Instance.bulletnum == 1)
            {
                MonsterHp -= BulletManager.Instance.bulletPower2;
            }
            ObjectPool.Instance.Return(collision.gameObject);
        }
    }


}

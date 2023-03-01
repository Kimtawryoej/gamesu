using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reach : Connection<Reach>
{
    public static float Hp;
    public Action<float> action = (float H) => Hp = H;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonsterBullet") && collision.transform.localScale.y == -2.634f)
        {
            Debug.Log("Ww");
            Hp--;
            ObjectPool.Instance.RETURN(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            Hp -= BulletManager.Instance.bullePower[0];
            ObjectPool.Instance.RETURN(collision.gameObject);
           
        }
        else if (collision.gameObject.CompareTag("bullet2"))
        {
            Hp -= BulletManager.Instance.bullePower[1];
            ObjectPool.Instance.RETURN(collision.gameObject);
        }
    }
}

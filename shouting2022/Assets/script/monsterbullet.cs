using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterbullet : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("AAA");
            move.Instance.hit();
            PoolingManager.Instance.ReturnBullet(key, this);
        }
    }
}
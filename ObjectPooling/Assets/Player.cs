using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    float curDelay = 0;
    private void Update()
    {
        if (Input.anyKey && curDelay > 0.1f)
        {
            Bullet bullet = PoolingManager.Instance.GetBullet();
            bullet.transform.position = transform.position;
            curDelay = 0;
        }
        curDelay += Time.deltaTime;
    }
}
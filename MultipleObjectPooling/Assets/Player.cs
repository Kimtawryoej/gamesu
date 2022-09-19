using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    float curDelay;
    [SerializeField] string poolKey = "Player";
    private void Update()
    {
        if(Input.anyKey && curDelay > 0.1f)
        {
            Debug.Log("Fire");
            Bullet bullet = PoolingManager.Instance.GetBullet(poolKey, bulletPrefab);
            bullet.transform.position = transform.position;
            curDelay = 0;
        }
        curDelay += Time.deltaTime;
    }
}
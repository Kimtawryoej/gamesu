using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Connection<PlayerBullet>
{
    float speed = 0.006f;
    float time;

    void Update()
    {
        if (transform.position.y < 6f)
        {
            transform.Translate(new Vector3(0, speed, 0));
        }
        else if (transform.position.y > 6f)
        {
            ObjectPool.Instance.Return(gameObject);
            
        }
    }
}

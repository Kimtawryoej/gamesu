using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bulletlaunch
{
    public static void Launch(this Transform min, int num, GameObject Bullet, float position)
    {
        ObjectPool.Instance.objectpool(Bullet, min.position, Quaternion.identity);
        for (int i = 0; i < num; i++)
        {
            ObjectPool.Instance.objectpool(Bullet, min.position + new Vector3(position * i, 0, 0), Quaternion.Euler(0, 0, i * 9));
            ObjectPool.Instance.objectpool(Bullet, min.position + new Vector3(-position * i, 0, 0), Quaternion.Euler(0, 0, i * -9));
        }
    }
}

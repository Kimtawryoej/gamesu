using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance { get; private set; }// <-- ÇÁ·ÎÆÛÆ¼ //½Ì±ÛÅæ
    Dictionary<string, Queue<Bullet>> objectpool = new Dictionary<string, Queue<Bullet>>();

    public Bullet GetBullet(string key, GameObject bulletPrefab)
    {
        Bullet bullet = null;
        if(objectpool.ContainsKey(key))
        {
            if (objectpool[key].Count > 0)
            {
                bullet = objectpool[key].Dequeue();
                bullet.gameObject.SetActive(true);
            }
            else
            {
                bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
                bullet.key = key;
                bullet.transform.SetParent(transform);
            }
        }
        else
        {
            objectpool.Add(key, new Queue<Bullet>());

            bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            bullet.key= key;
            bullet.transform.SetParent(transform);
        }
       return bullet;
    }

    public void ReturnBullet(string key, Bullet bullet)
    {
        objectpool[key].Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }

}

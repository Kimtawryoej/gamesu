using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance { get; private set; } //싱글톤
    Dictionary<string, Queue<Bullet>> objectPools = new Dictionary<string, Queue<Bullet>>(); //키가 string형이고 값이 오브젝트 풀인 딕셔너리 (키를 이용해 여러 개의 오브젝트 풀을 관리)

    public Bullet GetBullet(string key, GameObject bulletPrefab)
    {
        Bullet bullet = null;
        if(objectPools.ContainsKey(key)) //딕셔너리에 키가 등록되어있으면
        {
            //해당 키의 오브젝트 풀의 총알 갯수 체크
            if (objectPools[key].Count > 0)
            {
                bullet = objectPools[key].Dequeue();
                bullet.gameObject.SetActive(true);
            }
            else
            {
                bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
                bullet.key = key;
                bullet.transform.SetParent(transform);
            }
        }
        else //딕셔너리에 키가 등록되어있지 않으면
        {
            objectPools.Add(key, new Queue<Bullet>()); //키 할당

            bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            bullet.key = key;
            bullet.transform.SetParent(transform);
        }
        return bullet;
    }
    public void ReturnBullet(string key, Bullet bullet)
    {
        objectPools[key].Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance { get; private set; } //�̱���
    Dictionary<string, Queue<Bullet>> objectPools = new Dictionary<string, Queue<Bullet>>(); //Ű�� string���̰� ���� ������Ʈ Ǯ�� ��ųʸ� (Ű�� �̿��� ���� ���� ������Ʈ Ǯ�� ����)

    public Bullet GetBullet(string key, GameObject bulletPrefab)
    {
        Bullet bullet = null;
        if(objectPools.ContainsKey(key)) //��ųʸ��� Ű�� ��ϵǾ�������
        {
            //�ش� Ű�� ������Ʈ Ǯ�� �Ѿ� ���� üũ
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
        else //��ųʸ��� Ű�� ��ϵǾ����� ������
        {
            objectPools.Add(key, new Queue<Bullet>()); //Ű �Ҵ�

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
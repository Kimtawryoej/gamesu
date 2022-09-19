using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    //�̱��� ����
    public static PoolingManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] GameObject bulletPrefab;
    Queue<Bullet> bulletPool = new Queue<Bullet>(); //��Ȱ��ȭ ������ �Ѿ��� ������ ������Ʈ Ǯ
    public Bullet GetBullet()
    {
        //���ú����� �� �ʱ�ȭ���ϸ� ���� ���� ���� ������
        Bullet bullet = null; //��ȯ �� �Ѿ�
        if (bulletPool.Count > 0) //bulletPool�� ����ִ� �Ѿ��� 0�� �̻��̸� = ������Ʈ Ǯ�� �Ѿ��� ���������
        {
            bullet = bulletPool.Dequeue(); //Ǯ���� ������
            bullet.gameObject.SetActive(true);
        }
        else //������Ʈ Ǯ�� �Ѿ��� ������
        {
            bullet = Instantiate(bulletPrefab).GetComponent<Bullet>(); //���� ����
            bullet.transform.SetParent(transform);
        }
        return bullet; //�Ѿ� ��ȯ
    }
    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); //�� �� �Ѿ��� ��Ȱ��ȭ
        bulletPool.Enqueue(bullet); //�ٽ� Ǯ�� �ֱ�
    }
}
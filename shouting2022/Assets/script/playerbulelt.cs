using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbulelt : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("monster"))
        {
            Debug.Log("f");
            //monster.Instance.Hit(); // �̱��� ������ ���� �ϳ��� �ִ°Ÿ� ���� ����÷��� ���°ǵ� ������Ʈ Ǯ�� ������ �������鼭 �������� 
            collision.gameObject.GetComponent<monster>().Hit();
            PoolingManager.Instance.ReturnBullet(key, this);
        }
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullet2 : Bullet
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("monster"))
        {
            Debug.Log("f");
            //monster.Instance.Hit(); // �̱��� ������ ���� �ϳ��� �ִ°Ÿ� ���� ����÷��� ���°ǵ� ������Ʈ Ǯ�� ������ �������鼭 �������� 
            collision.gameObject.GetComponent<monster>().Hit2();
            PoolingManager.Instance.ReturnBullet(key, this);
        }
    }
}
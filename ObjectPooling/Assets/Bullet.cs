using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    IEnumerator C_Move()
    {
        //3�� �Ŀ� �ڱ� �ڽ��� ������Ʈ Ǯ�� �̵���Ŵ

        for(float t = 0; t < 3; t += Time.deltaTime)
        {
            transform.position += Vector3.forward * Time.deltaTime * 20;
            yield return null;
        }
        PoolingManager.Instance.ReturnBullet(this);
    }
    //gameObject�� Ȱ��ȭ�Ǿ��� �� ����
    private void OnEnable()
    {
        StartCoroutine(C_Move());
    }
}

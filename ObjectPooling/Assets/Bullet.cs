using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    IEnumerator C_Move()
    {
        //3초 후에 자기 자신을 오브젝트 풀로 이동시킴

        for(float t = 0; t < 3; t += Time.deltaTime)
        {
            transform.position += Vector3.forward * Time.deltaTime * 20;
            yield return null;
        }
        PoolingManager.Instance.ReturnBullet(this);
    }
    //gameObject가 활성화되었을 때 실행
    private void OnEnable()
    {
        StartCoroutine(C_Move());
    }
}

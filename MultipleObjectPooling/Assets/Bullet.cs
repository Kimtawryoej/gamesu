using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string key;
    IEnumerator C_Move()
    {
        for(float t = 0; t < 3; t += Time.deltaTime)
        {
            transform.position += Vector3.forward * Time.deltaTime * 20;
            yield return null;
        }
        PoolingManager.Instance.ReturnBullet(key, this);
    }
    private void OnEnable()
    {
        StartCoroutine(C_Move());
    }
}
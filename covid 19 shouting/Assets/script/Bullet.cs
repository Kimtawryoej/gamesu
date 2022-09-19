using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    IEnumerator C_Move()
    {
        for (float t = 0; t < 3; t += Time.deltaTime)
        {
            transform.position += Vector3.up * Time.deltaTime * 20;
            yield return null;
        }
        pool.Instance.ReturnBullet(this);
    }

    private void OnEnable()
    {
        StartCoroutine(C_Move());
    }
}

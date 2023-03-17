using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomRang : MonoBehaviour
{
    public static BoomRang instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Instantiate(PlayerBoom.instance.g[1], transform.position, Quaternion.identity);
        StartCoroutine(X.instance.x());
        StartCoroutine(X.instance.destory());
        StartCoroutine(destory());
    }

    IEnumerator destory()
    {
        yield return new WaitForSeconds(3);
        Instantiate(PlayerBoom.instance.g[2], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

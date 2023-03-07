using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destory());
        StartCoroutine(destory2());
    }

   IEnumerator destory()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    IEnumerator destory2()
    {
        yield return new WaitUntil(() => Raser.Instance.gameObject.activeSelf);
        Destroy(gameObject);
    }
}

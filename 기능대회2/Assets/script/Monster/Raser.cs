using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destory());
    }

   IEnumerator destory()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

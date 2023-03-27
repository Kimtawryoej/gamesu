using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class partical : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destory());
    }

    IEnumerator destory()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dir : MonoBehaviour
{
    public static Dir Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(destory());
    }


    IEnumerator destory()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
  

    public IEnumerator destory3()
    {
        Destroy(gameObject);
        yield return null;
    }
}

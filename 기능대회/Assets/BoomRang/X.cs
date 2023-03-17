using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : MonoBehaviour
{
    public static X instance;
    private void Awake()
    {
        instance = this;
    }

    public IEnumerator x()
    {
        WaitForSeconds wait = new WaitForSeconds(0.3f);
        while (BoomRang.instance.gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            yield return wait;
            gameObject.SetActive(false);
            yield return wait;
        }
    }
    public IEnumerator destory()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}

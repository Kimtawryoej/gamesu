using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixwdStar : MonoBehaviour
{
    float t;
    // Start is called before the first frame update
    void Start()
    {

        if (gameObject.CompareTag("Planet"))
        {
            StartCoroutine(scale());
            StartCoroutine(desto2());
        }
        else
            StartCoroutine(desto());
    }

    IEnumerator desto()
    {
        yield return new WaitUntil(()=> transform.position.y < -5.66f);
        Destroy(gameObject);
    }
    IEnumerator desto2()
    {
        yield return new WaitUntil(() => transform.position.y < -10f);
        Destroy(gameObject);
    }
    IEnumerator scale()
    {
        while(true)
        {
            t += Time.deltaTime;
            transform.localScale = new Vector3(2.1839f + t*5, 2.1839f + t*5, 2.1839f + t * 5);
            yield return null;
        }
    }
}

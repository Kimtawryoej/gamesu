using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoom : MonoBehaviour
{
    public GameObject boom;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ins());
    }

   IEnumerator ins()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destory());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destory()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

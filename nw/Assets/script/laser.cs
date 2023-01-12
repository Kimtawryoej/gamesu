using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Laser());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Laser()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            LaserObject.Instance.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            LaserObject.Instance.gameObject.SetActive(false);
        }
    }
}

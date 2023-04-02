using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomTriger : SingleTone<BoomTriger>
{
    SphereCollider sphereCollider;
    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        StartCoroutine(big());
    }
    IEnumerator big()
    {
        while(sphereCollider.radius < 17)
        {
            sphereCollider.radius += 2f;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Unit>().Attack = -3;
            other.gameObject.GetComponent<Unit>().HpManager(other.gameObject.GetComponent<Unit>().Hp);
            other.gameObject.GetComponent<Unit>().Attack = -1;
            Debug.Log(other.name + ":" + other.gameObject.GetComponent<Unit>().Hp);
        }
    }
}

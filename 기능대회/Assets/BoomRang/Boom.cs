using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public LayerMask layerMask;
    public static Boom instance;
    float t;
    bool Bool = true;
    Vector3 v;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(destory());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerManager.instance.OnTriggerEnter2D(collision);
    }

    IEnumerator destory()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

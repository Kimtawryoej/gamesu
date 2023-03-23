using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        StartCoroutine(destory());
    }
    // UpFdate is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.fixedDeltaTime, 0);
    }

    IEnumerator destory()
    {
        yield return new WaitUntil(()=>transform.position.z >55);
        Destroy(gameObject);
    }
}

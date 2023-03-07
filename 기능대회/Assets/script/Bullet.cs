using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    public float speed;
    float t;
    Vector3 v;
    void Start()
    {
        instance = this;
        if (gameObject.CompareTag("MonsterBullet"))
        {
            //transform.position = Monster.Instance.position;
            StartCoroutine(move());
        }
        StartCoroutine(stop());
        StartCoroutine(Bezior());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.fixedDeltaTime, 0);
       
    }
    IEnumerator Bezior()
    {
        yield return new  WaitUntil(()=>Boss.instance.pattern == 3);
        v = new Vector3(Random.Range(-5.38f, 4.99f), Random.Range(-5, 0), 0);
    }
    IEnumerator move()
    {
        transform.ELUR(Player.Instance.transform.position);
        yield return null;
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PlayerBullet"))
            TriggerManager.instance.OnTriggerEnter2D(collision);
    }
}

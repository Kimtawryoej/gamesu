using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : Unit
{
    public static Bullet instance;
    public float speed;
    float t;
    Vector3 v;
    void Start()
    {
        instance = this;
        StartCoroutine(move());
        if (gameObject.CompareTag("PlayerBullet"))
        {
            type = UnitType.Player;
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
        yield return new WaitUntil(() => Boss.instance.pattern == 3);
        v = new Vector3(Random.Range(-5.38f, 4.99f), Random.Range(-5, 0), 0);
    }
    IEnumerator move()
    {
        yield return new WaitUntil(() => (gameObject.CompareTag("BossBullet") && Boss.instance.pattern == 2));
        for (float i = 0; i < 3; i+= Time.deltaTime)
        {
            transform.ELUR(Player.Instance.transform.position);
            yield return null;
        }
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PlayerBullet"))
        {
            TriggerManager.instance.GAM(gameObject);
            TriggerManager.instance.OnTriggerEnter2D(collision);
        }
        if (gameObject.CompareTag("MonsterBullet") || gameObject.CompareTag("BossBullet"))
        {
            TriggerManager.instance.GAM(gameObject);
            TriggerManager.instance.OnTriggerEnter2D(collision);//플레이어 총알 사라지게 하기
        }
    }
}

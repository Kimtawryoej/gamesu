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
        if (gameObject.CompareTag("MonsterBullet"))
        {
            //transform.position = Monster.Instance.position;
            StartCoroutine(move());
            type = UnitType.Enemy;
        }
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
        yield return new  WaitUntil(()=>Boss.instance.pattern == 3);
        v = new Vector3(Random.Range(-5.38f, 4.99f), Random.Range(-5, 0), 0);
    }
    IEnumerator move()
    {
        //transform.ELUR(Player.Instance.transform.position);
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
        if (gameObject.CompareTag("MonsterBullet"))
            if (collision.gameObject.CompareTag("Player"))
            {
                TriggerManager.instance.monsterdata = collision;
                Player.Instance.ChangeHp(-1);
                Camera.Instance.Animation.SetBool("Move", true);
                Instantiate(TriggerManager.instance.Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            }
    }
}

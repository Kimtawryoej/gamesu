using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;
using static UnityEngine.ParticleSystem;

public class Monster : Unit
{

    public float MonsterAttack = 1;
    public GameObject Bullet;
    public Vector3 position;
    public GameObject partical;
    public static Monster Instance { get; private set; }
    public override void OnDie(Collider2D collision)
    {
        ScoreManager.instance.uiScore = ScoreManager.instance.findscore(20);
        Destroy(collision.gameObject);
        Instantiate(partical, collision.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        // 죽었을때 이팩트
        // 죽었으때 사운드
    }
    public void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (gameObject.CompareTag("Normal"))
        {
            type = UnitType.Enemy;
            hp = MonsterHpManager.instance.normal1;
            maxHp = MonsterHpManager.instance.normal1;
        }
        else if (gameObject.CompareTag("RaserMonster"))
        {
            type = UnitType.Enemy;
            hp = MonsterHpManager.instance.meteor;
            maxHp = MonsterHpManager.instance.meteor;
        }
        StartCoroutine(stop());
        StartCoroutine(move());
        if (gameObject.CompareTag("Normal"))
        {
            StartCoroutine(Bullet2());
        }
        Debug.Log("생성");
    }
    public void FixedUpdate()
    {
        position = transform.position;
        transform.Translate(0, -3.5f * Time.fixedDeltaTime, 0);
    }

    IEnumerator move()
    {


        transform.ELUR(Player.Instance.transform.position);
        yield return null;
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    IEnumerator Bullet2()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true)
        {
            yield return wait;

            for (int i = 0; i < 7; i++)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 60));
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("Boom") || collision.gameObject.CompareTag("Player"))
        {
            TriggerManager.instance.GAM(gameObject);
            TriggerManager.instance.OnTriggerEnter2D(collision);//플레이어 총알 사라지게 하기
        }
    }
}

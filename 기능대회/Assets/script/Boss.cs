using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : Unit
{

    public GameObject BossBullet;
    public GameObject HandRang;
    public float pattern;
    public static Boss instance;
    public Animator animator;
    public GameObject partical;
    public List<GameObject> bossposition;
    Vector3 position;
    public float speed = 0.6f;
    GameObject afterposition;
    public GameObject 무기;
    public override void OnDie(Collider2D collision)
    {
        GameManager.instance.time = 0;
        for (int i = 0; i < 3; i++)
        {
            ItemManager.Instance.c = UnityEngine.Random.Range(0, 5);
            Instantiate(ItemManager.Instance.Key[ItemManager.Instance.c].gameObject, Boss.instance.gameObject.transform.position, Quaternion.identity);
        }
        //Map.speed = -6;
        BossHpUi.instance.gameObject.SetActive(false);
        ScoreManager.instance.uiScore = ScoreManager.instance.findscore(50);
        gameObject.SetActive(false);
        Instantiate(partical, collision.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        // 죽었을때 이팩트
        // 죽었으때 사운드
    }
    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
        type = UnitType.Enemy;
        hp = MonsterHpManager.instance.boss;
        maxHp = MonsterHpManager.instance.boss;
    }
    void OnEnable()
    {
        StartCoroutine("PATTERNchoice");
        if (gameObject.CompareTag("boss"))
        {
            StartCoroutine("Move");
            StartCoroutine(PATTERN());
        }
        else if (gameObject.CompareTag("boss2"))
        {
            StartCoroutine(PATTERN2());
        }
    }
    private void Update()
    {
        if (hp <= 0)
            gameObject.SetActive(false);

    }
    IEnumerator PATTERN()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        WaitForSeconds wait2 = new WaitForSeconds(5f);
        while (true)
        {
            switch (pattern)
            {
                case 1:
                    StopCoroutine("Move");
                    StartCoroutine("Move");
                    speed = 0.6f;
                    for (int i = 0; i < 12; i++)
                    {
                        Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, i * 30));
                    }
                    yield return wait;
                    break;
                case 2:
                    StopCoroutine("Move");
                    StartCoroutine("Move");
                    speed = 0.6f;
                    Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, 0));
                    Debug.Log("2");
                    yield return wait;
                    break;
                case 3:
                    StopCoroutine("Move");
                    if (!Raser.Instance.gameObject.activeSelf)
                    {
                        GameManager.instance.AttackRang[0].SetActive(true);
                    }
                    yield return wait2;
                    Raser.Instance.gameObject.SetActive(true);
                    break;
                case 4:
                    if(!Bossskill4.instance.gameObject.activeSelf)
                        BossRang.Instance.gameObject.SetActive(true);
                    break;
            }
            yield return wait;
        }
    }
    IEnumerator PATTERN2()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        WaitForSeconds wait2 = new WaitForSeconds(1.5f);
        WaitForSeconds wait3 = new WaitForSeconds(9.3f);
        while (true)
        {
            switch (pattern)
            {
                case 1:
                    BossRang.Instance.gameObject.SetActive(true);
                    yield return wait;
                    break;
                case 2:
                    BossSkill.Instance.animator.SetBool("Skill1", true);
                    yield return wait2;
                    break;
                case 3:
                    BossSkill.Instance.animator.SetBool("찍기", true);
                    yield return wait2;
                    BossSkill.Instance.animator.SetBool("찍기", false);
                    yield return wait;
                    break;
                case 4:
                    무기.SetActive(false);
                    BossMove.Instance.animator.SetBool("Pattern",true);
                    Debug.Log("WWWWW");
                    yield return new WaitUntil(()=> BossMove.Instance.animator.GetCurrentAnimatorStateInfo(0).IsName("move") && BossMove.Instance.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
                    무기.SetActive(true);
                    BossMove.Instance.animator.SetBool("Pattern", false);
                    break;
            }
            yield return wait;
        }
    }
    IEnumerator PATTERNchoice()
    {
        WaitForSeconds wait = new WaitForSeconds(7);
        while (true)
        {
            yield return wait;
            pattern = Random.Range(1, 5);
        }
    }
    IEnumerator Move()
    {
        yield return null;
        Debug.Log("@2");
        while (true)
        {
            position = transform.position;
            afterposition = bossposition[Random.Range(0, 5)];
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(position, afterposition.transform.position, i);
                yield return null;

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

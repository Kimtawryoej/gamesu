using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Boss : Unit
{
    float pattern = 0;
    public GameObject BossBullet;
    public GameObject Raser;
    public GameObject attackrange;
    public Camera camera;
    public GameObject chaging;
    public static Boss instance;
    public List<GameObject> targetposition;
    public Animator animator;
    public GameObject rang;

    public override void DIE()
    {
        if (GameManager.Instance.find == gameObject)
        {
            GameManager.Instance.Monsters = new Monster[0];
            GameManager.Instance.Length.Clear();
            GameManager.Instance.find = null;
        }
        gameObject.SetActive(false);
        Ui.Instance.BossHp.gameObject.SetActive(false);
        TriggerManager.Instance.table.scroe += 100f;
    }



    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);

    }
    void Start()
    {
        StartCoroutine(Bullet());
        StartCoroutine(patterChange());
        StartCoroutine(positionMove());
    }

    IEnumerator Bullet()
    {
        WaitForSeconds wait = new WaitForSeconds(1.5f);
        WaitForSeconds wait2 = new WaitForSeconds(0.5f);
        while (true)
        {

            switch (pattern)
            {
                case 0:
                    for (int i = 1; i < Random.Range(2, 5); i++)
                    {
                        Instantiate(Raser, transform.position + new Vector3(Random.Range(-16, 16), 0, Random.Range(-16, 16)), Quaternion.Euler(180, 10 * i, 0));
                        yield return null;
                    }
                    yield return wait2;
                    break;
                case 1:
                    if (gameObject.name == "Boss2")
                    {
                        for (int i = 1; i < 30; i++)
                        {
                            Instantiate(BossBullet, transform.position, Quaternion.Euler(90, 0, 10 * i));
                            Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 90, 10 * i));
                            yield return null;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < 30; i++)
                        {
                            Instantiate(BossBullet, transform.position, Quaternion.Euler(90, 0, 10 * i));
                            yield return null;
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            Instantiate(attackrange, new Vector3(Random.Range(-44.2f, 44.2f), -48.6f, Random.Range(7.7f, -35.91f)), Quaternion.Euler(90, 0, 0));
                        }
                    }
                    yield return wait;
                    break;
                case 2:

                    if (gameObject.name == "Boss2")
                    {
                        animator.SetBool("Attack", false);
                        animator.SetBool("Attack", true);
                        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
                        {
                            Instantiate(rang, transform.position, Quaternion.Euler(0, 0, 60.744f));
                            animator.SetBool("Attack", false);
                        }
                    }
                    else
                        Instantiate(chaging, transform.position + new Vector3(0, 0, -11), Quaternion.identity);
                    yield return wait;
                    break;

            };
        }
    }
    IEnumerator patterChange()
    {
        while (true)
        {
            Debug.Log(pattern);
            yield return new WaitForSeconds(7);
            if (pattern == 2)
                pattern = -1;
            pattern++;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") && Hp != 0)
        {
            Debug.Log("Ww");
            HpManager(1);
            Instantiate(TriggerManager.Instance.partical, transform.position, Quaternion.identity);
        }
    }
    IEnumerator positionMove()
    {
        yield return null;
        while (true)
        {
            Vector3 myposition = transform.position;
            Vector3 Targetposition = targetposition[Random.Range(0, 5)].transform.position;
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(myposition, Targetposition, i * 0.5f);
                yield return null;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}

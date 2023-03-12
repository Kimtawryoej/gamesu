using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject BossBullet;
    public float pattern;
    public static Boss instance;
    public List<GameObject> bossposition;
    Vector3 position;
    float speed = 0.6f;
    GameObject afterposition;
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        StartCoroutine("Move");
        StartCoroutine(PATTERNchoice());
        StartCoroutine(PATTERN());
    }
    private void Update()
    {
        if (TriggerManager.instance.MonsterHp[GameObject.FindWithTag("boss")] <= 0)
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
                    Instantiate(BossBullet, transform.position, Quaternion.identity);
                    Debug.Log("1");
                    yield return wait;
                    break;
                case 2:
                    StopCoroutine("Move");
                    StartCoroutine("Move");
                    speed = 0.6f;
                    Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, 30));
                    Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, -30));
                    Debug.Log("2");
                    yield return wait;
                    break;
                case 3:
                    StopCoroutine("Move");
                    if(!Raser.Instance.gameObject.activeSelf)
                    {
                        GameManager.instance.AttackRang[0].SetActive(true);
                    }
                    yield return wait2;
                    Raser.Instance.gameObject.SetActive(true);
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
            pattern = Random.Range(1, 4);
        }
    }
    IEnumerator Move()
    {
        yield return null;
        while (true)
        {
            position = transform.position;
            afterposition = bossposition[Random.Range(0, 5)];
            for (float i = 0; i < 1; i += Time.deltaTime)
            {

                transform.position = Vector3.Lerp(position, afterposition.transform.position, i * speed);
                yield return null;

            }
        }
    }
}

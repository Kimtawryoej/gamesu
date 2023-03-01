using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : Connection<Boss>
{
    float t;
    public float Hp;
    public enum State { pattern, pattern2, pattern3 }
    public State patternAttack;
    bool execution = true;
    public bool sinho = false;
    // Start is called before the first frame update
    private void Start()
    {
        Hp = HpManager.MidMonsterHp;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Action action = () =>
        {
            patternAttack = (State)Random.Range(0, 3);
        };
        if (ExperienceManager.Instance.Lv == 4)
        {
            sinho = true;
            t+=Time.deltaTime;
            if (transform.position.y > 3.82f)
            {
                transform.Translate(0, -0.08f, 0);
            }
            if(t>=10)
            {
                Debug.Log("@@@");
                action();
                t=0;
            }
            switch (patternAttack)
            {
                case State.pattern:
                    if (execution)
                    {
                        StopAllCoroutines();
                        StartCoroutine(pattern());
                        execution = false;
                    }
                    break;
                case State.pattern2:
                    if (!execution)
                    {
                        StopAllCoroutines();
                        StartCoroutine(pattern2());
                        execution = true;
                    }
                    break;
                case State.pattern3:
                    if (execution)
                    {
                        StopAllCoroutines();
                        StartCoroutine(pattern3());
                        execution = false;
                    }
                    break;
            }
        }
    }
    IEnumerator pattern()
    {
        WaitForSeconds wit = new WaitForSeconds(1f);
        while (t <= 10)
        {
            transform.Launch(0, BulletManager.Instance.list[2],0);
            yield return wit;
        }
    }

    IEnumerator pattern2()
    {
        WaitForSeconds wit = new WaitForSeconds(2f);
        while (t <= 10)
        {
            transform.Launch(7, BulletManager.Instance.list[2],0);
            yield return wit;
        }
    }

    IEnumerator pattern3()
    {
        WaitForSeconds wit = new WaitForSeconds(2f);
        while (t <= 10)
        {
            Bulletlaunch.Launch(transform,5, BulletManager.Instance.list[2],0.5f);
            yield return wit;
        }
    }

    public  void OnTriggerEnter2D(Collider2D collision)
    {
        Reach.Instance.action(Hp);
        Reach.Instance.OnTriggerEnter2D(collision);
    }
}


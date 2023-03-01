using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Connection<NormalMonster>
{

    float time;
    float speed = -0.002f;
    public Coroutine cor;
    bool Set;
    GameObject a = null;

    private void Start()
    {
        StartCoroutine(two());
        
    }
    //움직이기
    void FixedUpdate()
    {
        if (transform.position.y > -5.4)
        {
            transform.Translate(new Vector3(0, -0.2f * Time.fixedDeltaTime, 0));
        }
        else
        {
            ObjectPool.Instance.Return(gameObject);
        }
        time += Time.deltaTime;
        if (Hp.Instance.MonsterHp < 0)
        {
            StartCoroutine(three());
        }
    }
    //플레이어 따라다니기
    IEnumerator one()
    {
        WaitForFixedUpdate fixedWait = new WaitForFixedUpdate(); //이걸 만들지 않으면 아래서 실행될때마다 계속 클래스를 만들기 때문에 이렇게 한번 만들고 계속 사용하게 한다.

        for (float t = 0; t < 5; t += Time.fixedDeltaTime)
        {
            transform.LookAt2D(Player.Instance.transform.position);
            yield return fixedWait;
        }

    }

    IEnumerator two()
    {
        WaitForSeconds fixedWait = new WaitForSeconds(3); //이걸 만들지 않으면 아래서 실행될때마다 계속 클래스를 만들기 때문에 이렇게 한번 만들고 계속 사용하게 한다.
        yield return fixedWait;
        ObjectPool.Instance.objectpool(NormalMonster.Instance.transform.position + new Vector3(0, -1.3f, 0), BulletManager.Instance.list[2], Quaternion.identity);
        StartCoroutine(two());
    }

    IEnumerator three()
    {
        yield return null;
        Debug.Log("WWW");
        ObjectPool.Instance.Return(gameObject);
        Player.Instance.score += 10;
    }
    private void OnEnable()
    {
        StartCoroutine(one());

        Hp.Instance.MonsterHp = 3;
    }
    //맞았을때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hp.Instance.OnCollisionEnter2D(collision);
    }
}

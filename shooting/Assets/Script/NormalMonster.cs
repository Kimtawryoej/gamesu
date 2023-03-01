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
    //�����̱�
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
    //�÷��̾� ����ٴϱ�
    IEnumerator one()
    {
        WaitForFixedUpdate fixedWait = new WaitForFixedUpdate(); //�̰� ������ ������ �Ʒ��� ����ɶ����� ��� Ŭ������ ����� ������ �̷��� �ѹ� ����� ��� ����ϰ� �Ѵ�.

        for (float t = 0; t < 5; t += Time.fixedDeltaTime)
        {
            transform.LookAt2D(Player.Instance.transform.position);
            yield return fixedWait;
        }

    }

    IEnumerator two()
    {
        WaitForSeconds fixedWait = new WaitForSeconds(3); //�̰� ������ ������ �Ʒ��� ����ɶ����� ��� Ŭ������ ����� ������ �̷��� �ѹ� ����� ��� ����ϰ� �Ѵ�.
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
    //�¾�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hp.Instance.OnCollisionEnter2D(collision);
    }
}

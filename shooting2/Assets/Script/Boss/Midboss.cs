using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Midboss : Connection<Midboss>
{
    public float Hp;
    public bool sinho = false;
    public float elur;
    public List<Transform> mids;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        Hp = HpManager.MidMonsterHp;
        StartCoroutine(Move());
        StartCoroutine(monsterBullet());
    }
    IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            Vector3 pos = gameObject.transform.position;
            Vector3 pos2 = mids[Random.Range(0, 5)].position;
            Debug.Log(pos2);
            for (float i = 0; i < 1; i += Time.deltaTime * 0.3f)
            {
                transform.position = Vector3.Lerp(pos, pos2, i);
                yield return null;
            }
        }
    }

    IEnumerator monsterBullet()
    {

        WaitForSeconds fix = new WaitForSeconds(5);
        WaitForSeconds wai2 = new WaitForSeconds(3);
        while (true)
        {
            yield return fix;
            if (Boom.Instance.co)
            {
                yield return wai2;
                Boom.Instance.co = false;
            }
            transform.Launch(2, BulletManager.Instance.list[2], 0);
            if (Boom.Instance.co)
            {
                yield return wai2;
                Boom.Instance.co = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Reach.Instance.OnTriggerEnter2D(collision);
        if (Hp <= 0)
        {
            HpManager.Instance.state = HpManager.State.MidBossState;
        }
    }
    public  void Update()
    {
        sinho = true;
    }
}

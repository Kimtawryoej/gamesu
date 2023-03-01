using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Connection<Player>
{

    public float score = 0;
    public int lv = 1;
    public int bulletnum = 0;
    public int signal = 0;
    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float Xmin, Xmax, Ymin, Ymax;
    Animator animator;
    public float time;
    public float bulletTime;
    public float changeTime;
    public float cooldown = 2;
    float a = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bulletTime += Time.deltaTime;
        changeTime += Time.deltaTime;
        // 막기
        float x1 = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        float y1 = Mathf.Clamp(transform.position.y, Ymin, Ymax);
        transform.position = new Vector3(x1, transform.position.y, transform.position.z);
        //움직임
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y);
        dir.Normalize();
        transform.position += dir * Time.deltaTime * speed;
        //회피
        if (Input.GetButtonDown("Jump") && time > 3)
        {
            animator.SetBool("space", true);
            transform.Translate(new Vector2(-x * 2, 0));
            time = 0;
        }
        else if (time > 1)
        {
            animator.SetBool("space", false);

        }
        //적 총알 반사
        if (Input.GetKey(KeyCode.G))
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 3f, Vector2.left, 0);
            if (hit.collider.CompareTag("bullet"))
            {
                Debug.Log(hit.collider.name);

                hit.collider.transform.rotation = Quaternion.Euler(0, 0, 180);
                hit.collider.transform.position = transform.position + new Vector3(2, 2, 0);
            }
        }
        //총알 발사
        if (Input.GetMouseButtonDown(1))
        {
            switch (bulletnum)
            {
                case 0:
                    if (bulletTime > cooldown)
                    {
                        ObjectPool.Instance.objectpool(transform.position + new Vector3(0, 1.3f, 0), BulletManager.Instance.list[0], Quaternion.identity);
                        for (int i = 1; i < 3; i++)
                        {
                            ObjectPool.Instance.objectpool(transform.position + new Vector3(0, 1.3f, 0), BulletManager.Instance.list[0], Quaternion.Euler(0, 0, 9 * i));
                            ObjectPool.Instance.objectpool(transform.position + new Vector3(0, 1.3f, 0), BulletManager.Instance.list[0], Quaternion.Euler(0, 0, -9 * i));
                        }
                        bulletTime = 0;
                    }
                    break;
                case 1:
                    if (bulletTime > cooldown)
                    {
                        ObjectPool.Instance.objectpool(transform.position + new Vector3(0, 1.3f, 0), BulletManager.Instance.list[1], Quaternion.identity);
                        bulletTime = 0;
                    }
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && changeTime > 3)
        {
            Debug.Log("변경");
            if (bulletnum == 0)
            {
                bulletnum = 1;
            }
            else if (bulletnum == 1)
            {
                bulletnum = 0;
            }
            changeTime = 0;
        }

        //레벨
        switch (lv)
        {
            case 2:
                if (a == 0)
                {
                    BulletManager.Instance.bulletPower = BulletManager.Instance.bulletPower + BulletManager.Instance.bulletPower * 0.2f;
                    BulletManager.Instance.bulletPower2 = BulletManager.Instance.bulletPower2 + BulletManager.Instance.bulletPower2 * 0.2f;
                    Hp.Instance.PlayerHp = Hp.Instance.PlayerHp + Hp.Instance.PlayerHp * 0.2f;
                    cooldown = cooldown * 0.8f;
                    a = 1;
                }
                break;
            case 3:
                if (a == 1)
                {
                    BulletManager.Instance.bulletPower = BulletManager.Instance.bulletPower + BulletManager.Instance.bulletPower * 0.2f;
                    BulletManager.Instance.bulletPower2 = BulletManager.Instance.bulletPower2 + BulletManager.Instance.bulletPower2 * 0.2f;
                    Hp.Instance.PlayerHp = Hp.Instance.PlayerHp + Hp.Instance.PlayerHp * 0.2f;
                    cooldown = cooldown * 0.8f;
                    a = 2;
                }
                break;
            case 4:
                if (a == 2)
                {
                    BulletManager.Instance.bulletPower = BulletManager.Instance.bulletPower + BulletManager.Instance.bulletPower * 0.2f;
                    BulletManager.Instance.bulletPower2 = BulletManager.Instance.bulletPower2 + BulletManager.Instance.bulletPower2 * 0.2f;
                    Hp.Instance.PlayerHp = Hp.Instance.PlayerHp + Hp.Instance.PlayerHp * 0.2f;
                    cooldown = cooldown * 0.8f;
                    a = 3;
                }
                break;
        }
        switch (score)
        {
            case 40:
                Player.Instance.score = 0;
                lv = 2;
                break;
            case 100:
                Player.Instance.score = 0;
                lv = 3;
                break;
            case 200:
                Player.Instance.score = 0;
                lv = 4;
                break;
        }

        //죽음
        //if (Hp.Instance.PlayerHp <= 0)
        //{
        //    Destroy(gameObject);
        //}

    }
    // 맞았을때
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Hp.Instance.OnCollisionEnter2D(collision);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : Connection<Shield>
{
    float t;
    float st;
    float circleR = 0.0015f; //������
    float deg; //����
    float objSpeed = 30f; //��� �ӵ�

    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        t += Time.deltaTime;
        Debug.Log(t);

        if (t < 15)
        {
            deg += Time.deltaTime * objSpeed;
            if (deg < 360)
            {
                float rad = Mathf.Deg2Rad * (deg);
                float x = circleR * Mathf.Sin(rad);
                float y = circleR * Mathf.Cos(rad);
                transform.position += new Vector3(x, y);
                transform.LookAt2D(Player.Instance.transform.position); //����� �ٶ󺸰� ���� ����
            }
            else
            {
                deg = 0;
            }
        }
        else if (t > 15)
        {
            Debug.Log("WWWWWWw");
            t = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MonsterBullet"))
        {
            ObjectPool.Instance.RETURN(collision.gameObject);
        }
    }

}

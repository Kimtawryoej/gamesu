using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    public GameObject prefab;
    public SpriteRenderer render;
    Collider2D Collider;
    public int hp = 15;
    Rigidbody2D Rigidbody;

    void Awake()
    {
        Instance = this;
        Collider = GetComponent<Collider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -1 * Time.fixedDeltaTime, 0));
        if (hp < 0 || transform.position.y < -5.6f)
        {
            transform.position = Vector3.zero;
            MonsterObjectPool.Instance.Disappear(prefab);
            hp = 15;
        }
        Rigidbody.velocity = Vector3.zero; //물리적 가속도를 0으로 만들어 뒤로 밀려나는거 방지
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet")) //왜 gameObject를 쓰는지 꼭 이해!!
        {
            hp -= 1;
            StartCoroutine(changecolor());
            
        }
    }

    public IEnumerator changecolor()
    {
        render.color = new Color(225, 0, 0);
        yield return new WaitForSeconds(0.2f);
        render.color = new Color(0, 0, 255);
        StopCoroutine(changecolor());

    }
}

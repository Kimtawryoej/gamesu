using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Connection<Player>
{
    SpriteRenderer spriteRenderer;
    GameObject g;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * Time.deltaTime * 3;
        //Àû ÃÑ¾Ë ¹Ý»ç
        if (Input.GetKey(KeyCode.G))
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 3f, Vector2.left, 0);
            if (hit.collider.CompareTag("MonsterBullet"))
            {
                 hit.collider.transform.localScale= new Vector3(2.634f, -2.634f, 2.634f);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonsterBullet"))
        {
            HpManager.Instance.PlayerHp--;
            ObjectPool.Instance.RETURN(collision.gameObject);
        }
    }
}

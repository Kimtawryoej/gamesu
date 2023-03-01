using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Connection<Boom>
{
    SpriteRenderer spriteRenderer;
    float t;
    public Animator animator;
    public bool co;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.sortingOrder = -1;
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.sortingOrder == 2)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Slerp(Player.Instance.transform.position, Player.Instance.transform.position + new Vector3(0, 5, 0), t * 2f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            spriteRenderer.sortingOrder = 2;
        }

        if (t > 1)
        {
            
            t = 0;
            spriteRenderer.sortingOrder = -1;
            animator.SetBool("New Bool", false);
            transform.position = Player.Instance.transform.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("!!!!");
        if (collision.gameObject.CompareTag("Monster") && spriteRenderer.sortingOrder == 2)
        {
            co = true;
            Debug.Log("Boom");
            animator.SetBool("New Bool", true);
            Monster.Hp--;
        }
    }
}

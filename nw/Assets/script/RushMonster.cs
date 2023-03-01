using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RushMonster : Connection<RushMonster>
{
    Vector3 position;
    int a = 0;
    Rigidbody2D Rigidbody;
    Animator animator;
    SpriteRenderer sprite;
    [SerializeField] LayerMask layerMask;
    void Start()
    {
        position = transform.position;
        animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(color());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, 4,Vector2.left, 0, layerMask);
        RaycastHit2D ray2 = Physics2D.CircleCast(transform.position, 1, Vector2.left, 0, layerMask);
        Debug.DrawRay(transform.position, Vector2.left, Color.blue, 5);
        if (ray.collider && a == 0 && sprite.material.color == Color.red)
        {
            animator.SetBool("Run", true);
            for (float i = 0; i < 1000; i += 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, 0.01f);
            }
            a = 1;
        }
        else if (!ray.collider && a == 1)
        {
            a = 0;
            StartCoroutine(time());
        }
        if (ray2.collider)
        {
            json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
            Player.hp--;
            Debug.Log(Player.hp);
            savepoint.siv = 0;
            SceneManager.LoadScene("Main");
        }
    }

    IEnumerator color()
    {
        while(true)
        {
            yield return new WaitForSeconds(4f);
            sprite.material.color = Color.red;
            yield return new WaitForSeconds(2f);
            sprite.material.color =Color.white ;
        }
    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < 10000; i++)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, position, 0.01f);
        }
        a = 0;
        animator.SetBool("Run", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Connection<Player>
{
    float[] save = new float[30];
    public static float time;
    public static Vector3 position;
    public static int hp = 1;
    public int move = 100;
    public int jump = 50;
    public int b = 0;
    public int a = 0;
    int c = 0;
    Vector3 vector;
    public Rigidbody2D Rigidbody;
    Animator animator;
    public int jumpPower = 5;
    public int jumpPower2 = 7;
    public int speed = 5;
    public int speed2 = 1;
    float h;
    public float j = -1;
    Vector3 dir;
    [SerializeField] LayerMask layerMask;
    public SpriteRenderer sprite;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
 
        if (hp <= 0)
        {
            NameUi.Instance.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Teleporting.Instance.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0)); // ui를 플레이어 위치에 띄우는 코드


        if(NameUi.Instance.gameObject.activeSelf == false)
        {
            time += Time.deltaTime;
        }
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, new Vector2(h, 0), 0.5f, layerMask);
        Debug.DrawRay(transform.position, new Vector2(h, 0), Color.blue);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(0, j), 1f, layerMask);
        Debug.DrawRay(transform.position, new Vector2(0, j), Color.blue);
        if (Input.GetButton("Horizontal"))
        {
            run();
            //speed = 5;

        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetButtonDown("Horizontal") && speed2 == 1)
        {
            move--;
        }

        if (Input.GetButtonDown("Jump") && Rigidbody.gravityScale == -1 && ray.collider)
        {
            Rigidbody.velocity = new Vector2(0, -jumpPower2);
            jump--;
        }

        if (Input.GetButtonDown("Jump") && ray.collider && !ray2.collider && jumpPower == 5 && Rigidbody.gravityScale == 1)
        {
            Rigidbody.velocity = new Vector2(0, jumpPower2);
            StartCoroutine(JumP());
            jump--;
        }
        if (ray.collider && ray2.collider && jumpPower == 5)
        {

            if (Input.GetButtonDown("Jump"))
            {


                Rigidbody.velocity = new Vector2(0, jumpPower);
                StartCoroutine(JumP());
                jump--;
            }

        }


       

        if (jumpPower == 5 && ray2.collider && !ray.collider && h == -1 && (a == 0 || b == 1))
        {
            if (Input.GetButtonDown("Jump"))
            {
                

                Rigidbody.velocity = new Vector2(0, jumpPower);
                StartCoroutine(JumP());
                jump--;
                a = 1;
                b = 0;
            }
        }
        else if (jumpPower == 5 && ray2.collider && !ray.collider && h == 1 && (a == 1 || b == 0))
        {
            if (Input.GetButtonDown("Jump"))
            {
                

                Rigidbody.velocity = new Vector2(0, jumpPower);
                StartCoroutine(JumP());
                jump--;
                a = 0;
                b = 1;
            }
        }

        if (ray2.collider)
        {
            speed = 0;
        }
        if (ray.collider)
        {
            a = 0;
            b = 0;
        }

        if (move < 1 || jump < 1)
        {
            if (move < 1)
            {
                speed2 = 0;
            }
            else if (jump < 1)
            {
                jumpPower = 0;
                jumpPower2 = 0;
            }
            if ((move < 1 && jump < 1))
            {
                
                SceneManager.LoadScene("Main");
                savepoint.siv = 0;
                hp--;
            }
        }
    }
    IEnumerator JumP()
    {
        if (Input.GetButton("Jump"))
        {
            animator.SetBool("jUMP", true);
            yield return new WaitForSeconds(0.6f);
            animator.SetBool("jUMP", false);
            speed = 5;
        }
    }

    void run()
    {
        h = Input.GetAxisRaw("Horizontal");
        sprite.flipX = h == -1;
        animator.SetBool("Run", true);
        dir = new Vector3(h, 0, 0);
        transform.position += speed * speed2 * dir * Time.deltaTime;
        vector = transform.position;
    }

    public float pushPower = 2.0F;
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Debug.Log("alfrlalfrl");
    //    Rigidbody body = hit.collider.attachedRigidbody;
    //    if (body == null || body.isKinematic)
    //        return;

    //    Vector2 pushDir = new Vector2(hit.moveDirection.x, 0);
    //    body.velocity = pushDir * pushPower;
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("box"))
        {
            collider.size = new Vector2(1.234565f, 1.40625f);
            collider.offset = new Vector2(-0.0195533f,0);
            Debug.Log(dir);
            Vector2 pushDir = new Vector2(dir.x, 0);
            collision.rigidbody.velocity = pushDir * pushPower;

        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("box"))
        {
            collider.size = new Vector2(0.6499026f, 1.40625f);
            collider.offset = new Vector2(-0.0195533f, 0);
        }
    }

}

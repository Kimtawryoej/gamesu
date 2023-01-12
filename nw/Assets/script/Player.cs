using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Connection<Player>
{
    //±èÅÂ¿¬
    public int hp = 3;
    public int move = 100;
    public int jump = 50;
    int b = 0;
    public int a = 0;
    int c = 0;
    Vector3 vector;
    public Rigidbody2D Rigidbody;
    Animator animator;
    public int jumpPower = 5;
    public int jumpPower2 = 7;
    int speed = 5;
    public int speed2 = 1;
    float h;
    public float j = -1;
    [SerializeField] LayerMask layerMask;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, new Vector2(h, 0), 0.5f, layerMask);
        Debug.DrawRay(transform.position, new Vector2(h, 0), Color.blue);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(0, j), 1f, layerMask);
        Debug.DrawRay(transform.position, new Vector2(0, j), Color.blue);
        if (Input.GetButton("Horizontal"))
        {
            run();
            speed = 5;

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
                Debug.Log("gg");

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
                Debug.Log("1");

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
                json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
                Player.Instance.transform.position = json.Instance.playerData.position;
                Player.Instance.move = json.Instance.playerData.Move;
                Player.Instance.jump = json.Instance.playerData.Jump;
                Player.Instance.jumpPower = json.Instance.playerData.JumpPower;
                Player.Instance.jumpPower2 = json.Instance.playerData.JumpPower2;
                Player.Instance.speed2 = json.Instance.playerData.Speed2;
                hp--;

            }
        }
        if (hp == 0)
        {
            SceneManager.LoadScene("Main");
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
        Vector3 dir = new Vector3(h, 0, 0);
        transform.position += speed * speed2 * dir * Time.deltaTime;
        vector = transform.position;
    }
}

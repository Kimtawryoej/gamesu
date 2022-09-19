using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    GameObject ran;
    public int speed = 40;
    public float jumpPower=8;
    Rigidbody2D rid;
    public float maxspeed;
    SpriteRenderer sprite;
    Animator ani;
    public GameObject mushroom;
    GameObject Mush;
    

    void Awake()
    {
        ran = GameObject.Find("goomba");
        rid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    void Update()
    {
        //velocity = ������ٵ��� ���� �ӵ�   //normalized = ������ ũ�⸦ 1�� ���� ����
        //if (Input.GetButtonUp("horizontal")) //��ư�� �ն��� ������ ���߱�
        //{
        //    rid.velocity = new Vector2(speed * (0), rid.velocity.y);
        //}
        CharacterState();
        

        //float direction = Input.GetAxisRaw("Horizontal");//������� ¥�ֽ� �ڵ� �����ִ��ڵ� ���ι���
        //rid.velocity = new Vector2(direction * maxspeed,rid.velocity.y); �����̰� �������� ����Ʋ�� ����X

        //ani.SetBool("isrun", direction != 0);
        //sprite.flipX = direction > 0 ? false : (direction < 0 ? true : sprite.flipX);  

    }

     void FixedUpdate()
     {
        Move();
     }
    void CharacterState()
    {

        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal")) && Input.GetAxisRaw("Horizontal") != 0)//�յڹٲٱ� ������ ��ģ����  �յڷ� ����� �ٲ��� �ʴ� ����
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (rid.velocity.x == 0)//�ִϸ����� �ٲٱ� 
        {
            ani.SetBool("isrun", false);
        }
        else
        {
            ani.SetBool("isrun", true);
        }

        if (Input.GetButtonDown("Jump") && !ani.GetBool("isjump"))//�������� �ƴҶ� �� ����
        {
            rid.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
            ani.SetBool("isjump", true);
        }
        if (rid.velocity.y == 0)
        {
            Debug.DrawRay(rid.position, Vector2.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(this.transform.position, Vector2.down, 5, LayerMask.GetMask("platform"));
            if (rayHit.collider != null)
            {
                ani.SetBool("isjump", false);
            }
        }
    }
    void Move()
    {
        float dir = Input.GetAxisRaw("Horizontal");//�����̱�
        rid.velocity = new Vector2(dir * maxspeed * 0.5f,rid.velocity.y); //�ӵ����� �������� ������ �ӵ��� �����ؼ� �� �ö���
        rid.velocity = new Vector2(Mathf.Clamp(rid.velocity.x,-maxspeed, maxspeed), rid.velocity.y);

        //rid.AddForce(new Vector2(speed*a, 0)); /�����༭ �ӵ��� ���� ���
        //if (rid.velocity.x > maxspeed)   //�ӵ� ����
        //{
        //    rid.velocity = new Vector2(maxspeed, rid.velocity.y);
        //}
        //else if (rid.velocity.x < maxspeed * (-1))
        //{
        //    rid.velocity = new Vector2(maxspeed * (-1), rid.velocity.y);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision) //�̽��׸� �ڽ��� ������ ���� �����ϰ� 1������ �������� ����
    {
        Debug.DrawRay(rid.position, Vector2.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(this.transform.position, Vector2.up, 1, LayerMask.GetMask("HeadBlock"));
        if (rayHit.collider != null)
        {
            rayHit.transform.GetComponent<HeadBlock>().Execute();
        }

        if (collision.gameObject.tag != "mushroom")
        {
            ani.SetBool("die1", false);
        }


        if (collision.gameObject.tag == "mushroom" && this.transform.position.y < 1.6f) //������ �������� ���ϸ� �ױ�
        {
            ani.SetBool("die1", true);
            Invoke("Down", 0.5f);
            Invoke("Del", 4);
        }
    }

    void Down()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    void Del()
    {

        Destroy(this.gameObject);
    }


}

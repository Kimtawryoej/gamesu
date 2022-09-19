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
        //velocity = 리지드바디의 현재 속도   //normalized = 백터의 크기를 1로 만든 상태
        //if (Input.GetButtonUp("horizontal")) //버튼에 손때면 움직임 멈추기
        //{
        //    rid.velocity = new Vector2(speed * (0), rid.velocity.y);
        //}
        CharacterState();
        

        //float direction = Input.GetAxisRaw("Horizontal");//선배님이 짜주신 코드 위에있는코드 줄인버전
        //rid.velocity = new Vector2(direction * maxspeed,rid.velocity.y); 움직이고 돌때마다 방향틀기 점프X

        //ani.SetBool("isrun", direction != 0);
        //sprite.flipX = direction > 0 ? false : (direction < 0 ? true : sprite.flipX);  

    }

     void FixedUpdate()
     {
        Move();
     }
    void CharacterState()
    {

        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal")) && Input.GetAxisRaw("Horizontal") != 0)//앞뒤바꾸기 오류도 고친버전  앞뒤로 제대로 바뀌지 않는 버그
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (rid.velocity.x == 0)//애니메이터 바꾸기 
        {
            ani.SetBool("isrun", false);
        }
        else
        {
            ani.SetBool("isrun", true);
        }

        if (Input.GetButtonDown("Jump") && !ani.GetBool("isjump"))//점프중이 아닐때 만 점프
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
        float dir = Input.GetAxisRaw("Horizontal");//움직이기
        rid.velocity = new Vector2(dir * maxspeed * 0.5f,rid.velocity.y); //속도고정 오느막길 에서도 속도가 일정해서 잘 올라가짐
        rid.velocity = new Vector2(Mathf.Clamp(rid.velocity.x,-maxspeed, maxspeed), rid.velocity.y);

        //rid.AddForce(new Vector2(speed*a, 0)); /힘을줘서 속도를 내는 방식
        //if (rid.velocity.x > maxspeed)   //속도 제한
        //{
        //    rid.velocity = new Vector2(maxspeed, rid.velocity.y);
        //}
        //else if (rid.velocity.x < maxspeed * (-1))
        //{
        //    rid.velocity = new Vector2(maxspeed * (-1), rid.velocity.y);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision) //미스테리 박스에 닿으면 버섯 생성하고 1마리만 나오도록 설정
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


        if (collision.gameObject.tag == "mushroom" && this.transform.position.y < 1.6f) //옆에서 굼바한테 당하면 죽기
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

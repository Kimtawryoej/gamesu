using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombaMove : MonoBehaviour
{
   
    Rigidbody2D rid;
    public float  maxspeed;
    SpriteRenderer sprite;
    Animator ani;
    public int direction = -1;
    GameObject forDestory;

    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        direction = -1;
        ani = GetComponent<Animator>();
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveANDturn();
        Tur5();
        //turn(r, rayHit2);

        Stop(); 
        Exit();

    }
    public void MoveANDturn()//왼쪽,오른쪽으로 가다가 아래 땅이 감지가 안되면 돌아서 다시 가기
    {
        //Vector2 z = new Vector2(rid.position.x + (-0.5f), rid.position.y);(였던것)
        //Debug.DrawRay(z, Vector3.down, new Color(0, 1, 0));
        
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position - Vector3.right * 0.5f, Vector3.down, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider == null)
        {
            direction = 1;
        }

        rayHit = Physics2D.Raycast(transform.position + Vector3.right * 0.5f, Vector3.down, 1, LayerMask.GetMask("platform"));
        if(rayHit.collider == null)
        {
            direction = -1;
        }

        rid.velocity = new Vector2(maxspeed * direction, rid.velocity.y);
    }


    void Tur5()//왼쪽,오른쪽으로 가다가 옆에벽이 감지가 되면 돌아서 다시 가기
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position - Vector3.right * 0.5f, Vector3.left, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider != null)
        {
            direction = 1;
        }

        rayHit = Physics2D.Raycast(transform.position + Vector3.right * 0.5f, Vector3.right, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider != null)
        {
            direction = -1;
        }

        rid.velocity = new Vector2(maxspeed * direction, rid.velocity.y);
    }

    void Exit()
    {
        ani.SetBool("die", false);
        Debug.DrawRay(transform.position, Vector3.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.up, 1, LayerMask.GetMask("player"));
        if (rayHit.collider != null)
        {
            ani.SetBool("die", true);
            Invoke("Down", 0.5f);
            Invoke("Del", 4);
        }

    }
    void Stop ()
    {
        if (ani.GetBool("die"))
        {
            maxspeed = 0;
        }
            
    }
    void Down()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }
    void Del()
    {
        forDestory = GameObject.Find("goomba");
        Destroy(forDestory);
    }
}
    //void turn(Vector2 o, RaycastHit2D p)//오른쪽으로 가다가 아래 땅이 감지가 안되거나 벽이 있으면 돌아서 다시 가기(였던것)
    //{
    //    //Vector2 q= new Vector2(rid.position.x + 0.5f, rid.position.y);
    //    //Debug.DrawRay(q, Vector3.forward, new Color(0, 1, 0));
    //    //RaycastHit2D rayHit = Physics2D.Raycast(q, Vector3.forward, 1, LayerMask.GetMask("platform"));
    //    //if (rayHit.collider != null)
    //    //{
    //    //    direction = -1;
    //    //}
    //    //else if (p.collider == null)
    //    //{
    //    //    direction = -1;
    //    //}

    //    //rid.velocity = new Vector2(maxspeed * direction, rid.velocity.y);

    //}


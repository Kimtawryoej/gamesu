using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomMiove : MonoBehaviour
{
    Rigidbody2D rid;
    public float maxspeed;
    SpriteRenderer sprite;
    public int direction = -1;
    public GameObject find;
    // Start is called before the first frame update
    void Start()
    { 
        rid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        direction = -1;
        find = GameObject.Find("mario");

    }

    // Update is called once per frame
    void Update()
    {
        Tur5();
        MoveANDturn();
    }



    public void MoveANDturn()//왼쪽,오른쪽으로 가다가 아래 땅이 감지가 안되면 돌아서 다시 가기
    {
        //Vector2 z = new Vector2(rid.position.x + (-0.5f), rid.position.y);(였던것)
        //Debug.DrawRay(z, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position + Vector3.right * 0.5f, Vector3.down, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider == null)
        {
            direction = -1;
        }


         rayHit = Physics2D.Raycast(transform.position - Vector3.right * 0.5f, Vector3.down, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider == null)
        {
            direction = 1;
        }

        rid.velocity = new Vector2(maxspeed * direction, rid.velocity.y);
    }


    void Tur5()//왼쪽,오른쪽으로 가다가 옆에벽이 감지가 되면 돌아서 다시 가기
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position + Vector3.right * 0.5f, Vector3.right, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider != null)
        {
            direction = -1;
        }


        rayHit = Physics2D.Raycast(transform.position - Vector3.right * 0.5f, Vector3.left, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider != null)
        {
            direction = 1;
        }

        rid.velocity = new Vector2(maxspeed * direction, rid.velocity.y);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            find.GetComponent<HeadBlock>().Execute();
            
        }
    }
}

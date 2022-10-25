using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Vector3 dir;
    public Vector3 Dir => dir;
    SpriteRenderer sprite;
    int cnt = 0;
    Animator ani;
    public Animator Ani => ani;
    Rigidbody2D rid;
    public Rigidbody2D Rigid => rid;
    private IState currentState;
    RaycastHit2D hit;
    public RaycastHit2D Hit => hit;
    int health = 3;
    int maxhealth = 3;
    bool isDie = false;
    bool isUnBeatTime = false;
    public Transform pos;
    public Vector2 boxsize;
    // --------------------------------------------------------------------e
    void Awake()
    {
        health = maxhealth;
        Instance = this;
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
        SetState(new Idle());
    }
    

    // -------------------------------------------------------------------------
    void Update()
    {

        currentState.Update();
        attack();
        CharacterState();


        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, z, 0);
        dir.Normalize();

        Debug.DrawRay(this.transform.position + new Vector3(h, z) * 1.0f, Vector3.forward, Color.blue);
        hit = Physics2D.Raycast(this.transform.position + dir  * 1.0f, Vector3.forward, 1, LayerMask.GetMask("map"));  //2d면 이렇게 쓰고 3d에서만 Physics2D hit넣어서 함 왜냐하면 반환형 때문
       
        if(health == 0)
        {
            Debug.Log("die");
            gameObject.SetActive(false);
        }

    }
    //--------------------------------------------------------
    public void SetState(IState nextState)
    {
        //기존의 상태가 존재 했다면  OnExit()호출
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = nextState;
        currentState.OnEnter(this);

    }

    //void Move()
    //{
    //    float h = Input.GetAxisRaw("Horizontal");
    //    float z = Input.GetAxisRaw("Vertical");
    //    dir = new Vector3(h,z,0);
    //    dir.Normalize();

    //    RaycastHit2D hit;
    //    Debug.DrawRay(this.transform.position + new Vector3(h, z) * 1.5f, Vector3.zero, Color.blue);
    //    hit = Physics2D.Raycast(this.transform.position + new Vector3(h, z) * 1.5f, Vector3.zero, 1,LayerMask.GetMask("map"));  //2d면 이렇게 쓰고 3d에서만 Physics2D hit넣어서 함 왜냐하면 반환형 때문
    //    if (hit)
    //    {
    //        //transform.position += dir * speed * Time.deltaTime;
    //        rid.velocity = dir * speed; // rid 를 쓸거라서 transform.position을 쓰지 않고 속도에 값을 넣어줘서 실행한다 rid쓰는데  transform.position을 쓰면 인식을 못해 아래로 떨어진다 중력때문에
    //    }
    //}
    //-----------------------------------------------------------------------
    void CharacterState()
    {
        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal")) && Input.GetAxisRaw("Horizontal") != 0)
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (rid.velocity.x == 0 && rid.velocity.y == 0)
        {
            ani.SetBool("isrun", false);
        }
        else
        {
            ani.SetBool("isrun", true);
        }
    }
    //--------------------------------------------------------------------
    // 몬스터 한테 맞으면 죽기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster" && collision.isTrigger  && !isUnBeatTime)
        {
            health--;
            Debug.Log(health);
            if(health >0)
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }
        }
    }


    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while(countTime < 10)
        {
            if(countTime%2 == 0)
            {
                sprite.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                sprite.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        sprite.color = new Color32(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
    }
    //----------------------------------------------
    
   void attack()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(pos.position, boxsize, 0);  //Physics2D는 유니티에서 2D로 구성된 게임을 위해 제공되는 물리를 위한 시뮬레이션엔진 ex)rigidbody,colider 
        foreach (Collider2D iitem in col)                                      //OverBoxAll은 위치와  박스 사이즈를 정하면 박스의  영역에서 해당레이서 마스크로 지정된 모든 게임 오브젝트 충돌체를 찾아 배열의 형태로 보관
        {
            if(iitem.tag == "Monster" && Input.GetMouseButtonDown(0))
            {
                Monster.Instance.takeDamage(); //singleton으로 singletone은 하나의 객체를 여러군데 사용하는것을 말한다 이 말처럼 Instance는 다른 스크립트에서  그기능을 불러와 쓰는거다.

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxsize);
    }
}


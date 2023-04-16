using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D Rigidbody2D;
    public List<GameObject> SavePosition = new List<GameObject>();
    float JumpCount;
    float JumpCountSet
    {
        get => JumpCount;
        set
        {
            if (JumpCount < value)
                JumpCount = value;
            StartCoroutine(JumpStop(value));
            
            }
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        animator.SetBool("Jump", false);
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(h, 0);
        if (dir == new Vector3(1, 0))
            spriteRenderer.flipX = false;
        else if (dir == new Vector3(-1, 0))
            spriteRenderer.flipX = true;
        if (dir == new Vector3(0, 0))
            animator.SetBool("Run", false);
        else
            animator.SetBool("Run", true);
        transform.position += dir * Time.deltaTime * 5;
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount == 0)
        {
            Rigidbody2D.AddForce(Vector2.up * 300, ForceMode2D.Force);
            Debug.Log("Ww");
            JumpCountSet = 1;
            animator.SetBool("Jump", true);
        }
    }
    IEnumerator JumpStop(float Value)
    {
        yield return new WaitForSeconds(1f);
        if (JumpCount >= Value)
            JumpCount = 0;
    }

    //IEnumerator PositionMove()
    //{
        
    //}
}

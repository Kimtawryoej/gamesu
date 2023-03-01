using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    public LayerMask mask;
    bool one = false;
    bool two = false;
    bool three = false;
    public int Speed = 5;
    Animator animator;
    public Vector3 dir;
    SpriteRenderer spriteRenderer;
    public static InputManager Instance;
    Input input;
    Dictionary<KeyCode, Action> keyDictionary;
    public float speed = 3.1f;
    float h;
    public int chance = 0;
    int savedata;
    float t;
    int a = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Action action = () =>
        {
            animator.SetBool("Idle", false);
            h = Input.GetAxis("Horizontal");
            dir = new Vector3(h, 0, 0);
            Player.Instance.transform.position += dir * Speed * Time.deltaTime;
        };
        Action Left = () =>
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Fly") && !animator.GetCurrentAnimatorStateInfo(0).IsName("New State 0"))
            {
                spriteRenderer.flipX = true;
                action();
            }
        };
        Action Right = () =>
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Fly") && !animator.GetCurrentAnimatorStateInfo(0).IsName("New State 0"))
            {
                spriteRenderer.flipX = false;
                action();
            }
        };
        Action H = () =>
        {
            animator.SetBool("FireAttack", true);
            RaycastHit2D hit = Physics2D.CircleCast(Player.Instance.transform.position, 10f, Vector2.right, 0, mask);
            if (hit && gameObject.CompareTag("Player"))
            {
                Fire.Instance.gameObject.SetActive(true);
                Fire.Instance.transform.position = new Vector2(hit.transform.position.x, hit.transform.position.y + 1);
            }
        };
        Action F = () =>
        {
            if (!three)
            {
                three = true;
                animator.SetFloat("Blend", 0);
                animator.SetTrigger("action");
                StartCoroutine(stop());

            }
        };
        Action Space = () => { animator.SetBool("Fly", true); };
        Action G = () => { animator.SetBool("fastMove", true); one = false; };
        Action Q = () =>
        {
            Canvas.instance.gameObject.SetActive(true);
        };
        keyDictionary = new Dictionary<KeyCode, Action>
        {
            { KeyCode.LeftArrow, Left},
            { KeyCode.RightArrow,Right},
            { KeyCode.H,H},
            { KeyCode.F,F},
            { KeyCode.Space,Space},
            { KeyCode.G,G},
            { KeyCode.Q,Q}
        };
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); ;
        animator.SetBool("fastMove", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Fly", false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attack", true);
        t += Time.deltaTime;
        if (Input.anyKey)
        {
            foreach (var key in keyDictionary)
            {
                if (Input.GetKey(key.Key))
                {
                    key.Value();
                }
            }
        }
        stopani();


    }
    void stopani()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fly") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.SetBool("Idle", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("FireManFlyMove") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && one == false)
        {
            animator.SetBool("fastMove", false);
            transform.position = new Vector3(transform.position.x + speed * h, transform.position.y, 0);
            one = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.SetBool("FireAttack", false);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("Idle", true);
        }
        if (Input.GetKeyDown(KeyCode.F) && two)
        {
            StopAllCoroutines();
            StartCoroutine(start());
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Canvas.instance.gameObject.SetActive(false);
        }
    }
    IEnumerator start()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        animator.SetBool("Attack", false);
        animator.SetFloat("Blend", 1);
        animator.SetTrigger("action");
        StartCoroutine(stop());
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(0.4f);
        two = true;
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        animator.SetBool("Attack", false);
        two = false;
        three = false;
    }
}

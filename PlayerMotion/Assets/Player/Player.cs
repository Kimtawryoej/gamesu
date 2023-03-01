using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }
    //void Start()
    //{
    //    Action Left = () => { spriteRenderer.flipX = true; };
    //    Action Right = () => { spriteRenderer.flipX = false; };
    //    Action H = () =>
    //    {
    //        animator.SetBool("FireAttack", true);
    //        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 10f, Vector2.right, 0, mask);
    //        if (hit)
    //        {
    //            Debug.Log("발견");
    //        }
    //    };
    //    Action F = () =>
    //    {
    //        if (!three)
    //        {
    //            three = true;
    //            animator.SetFloat("Blend", 0);
    //            animator.SetTrigger("action");
    //            StartCoroutine(stop());

    //        }
    //    };
    //    Action Space = () => { animator.SetBool("Fly", true); };
    //    Action G = () => { animator.SetBool("fastMove", true); one = false; };
    //    keyDictionary = new Dictionary<KeyCode, Action>
    //    {
    //        { KeyCode.LeftArrow, Left},
    //        { KeyCode.RightArrow,Right},
    //        { KeyCode.H,H},
    //        { KeyCode.F,F},
    //        { KeyCode.Space,Space},
    //        { KeyCode.G,G}
    //    };
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //    animator = GetComponent<Animator>(); ;
    //    animator.SetBool("fastMove", false);
    //    animator.SetBool("Idle", false);
    //    animator.SetBool("Fly", false);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    animator.SetBool("Attack", true);
    //    t += Time.deltaTime;
    //    Action action = () =>
    //    {
    //        animator.SetBool("Idle", false);
    //        h = Input.GetAxis("Horizontal");
    //        dir = new Vector3(h, 0, 0);
    //        transform.position += dir * Speed * Time.deltaTime;
    //    };

    //    if (Input.anyKey)
    //    {
    //        foreach (var key in keyDictionary)
    //        {
    //            if (Input.GetKeyDown(key.Key))
    //            {
    //                key.Value();
    //            }
    //        }
    //    }
    //    if (Input.GetButton("Horizontal") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Fly") && !animator.GetCurrentAnimatorStateInfo(0).IsName("New State 0")) //줄여야함
    //    {
    //        action();
    //    }
    //    else if (Input.GetButtonUp("Horizontal"))
    //    {
    //        animator.SetBool("Idle", true);
    //    }
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("FireManFlyMove") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && one == false) //줄여야함 
    //    {
    //        transform.position = new Vector3(transform.position.x + speed * h, transform.position.y, 0);
    //        one = true;
    //    }
    //    stopani();
    //    if (Input.GetKeyDown(KeyCode.F) && two)
    //    {

    //        Debug.Log("@");
    //        StopAllCoroutines();
    //        StartCoroutine(start());
    //    }


    //}
    //void stopani()
    //{
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fly") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
    //    {
    //        animator.SetBool("Idle", true);
    //    }
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("FireManFlyMove") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
    //    {
    //        animator.SetBool("fastMove", false);
    //    }
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
    //    {
    //        animator.SetBool("FireAttack", false);
    //    }
    //}
    //IEnumerator start()
    //{
    //    yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
    //    animator.SetBool("Attack", false);
    //    animator.SetFloat("Blend", 1);
    //    animator.SetTrigger("action");
    //    StartCoroutine(stop());
    //}
    //IEnumerator stop()
    //{
    //    yield return new WaitForSeconds(0.4f);
    //    two = true;
    //    yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
    //    animator.SetBool("Attack", false);
    //    two = false;
    //    three = false;
    //}
}

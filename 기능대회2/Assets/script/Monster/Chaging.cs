using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaging : MonoBehaviour
{
   
    Animator animator;
  
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("½ÇÇà", true);
        transform.LookAt(Player.instance.transform);
        StartCoroutine(des());
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Chaging") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            transform.position += transform.forward * 30 * Time.deltaTime;
        }
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}

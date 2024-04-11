using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill :Singleton<BossSkill>
{
   public  Animator animator;
    public GameObject Partical;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(anime());
    }
    IEnumerator anime()
    {
        while(true)
        {
            yield return new WaitUntil(() => (animator.GetCurrentAnimatorStateInfo(0).IsName("BossSkill") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f));
            Instantiate(Partical, new Vector3(-1.19f, -2.65f, 0), Quaternion.identity);
            animator.SetBool("Skill1", false);
        }
    }
    
}

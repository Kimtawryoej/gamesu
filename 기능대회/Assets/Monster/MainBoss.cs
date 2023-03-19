using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoss : Singleton<MainBoss>
{
   public  Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}

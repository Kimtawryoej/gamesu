using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : Singleton<BossMove>
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

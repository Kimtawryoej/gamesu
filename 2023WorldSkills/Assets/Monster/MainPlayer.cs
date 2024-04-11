using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Singleton<MainPlayer>
{
  public   Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("@2");
    }
}

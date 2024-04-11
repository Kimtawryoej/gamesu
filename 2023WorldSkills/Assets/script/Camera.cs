using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static Camera Instance;
    public Animator Animation;
    Vector3 position;
    void Awake()
    {
        Animation = GetComponent<Animator>();
        Animation.SetBool("Move", false);
        Instance = this;
    }

    private void Update()
    {
        if (Animation.GetCurrentAnimatorStateInfo(0).IsName("Camera") && Animation.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            Animation.SetBool("Move", false);
    }


}

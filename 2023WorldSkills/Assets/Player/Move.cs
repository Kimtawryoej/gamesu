using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    int speed = 5;
     float MultiKey;
    float firstKey;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Func<KeyCode, KeyCode, float, float> action = (k1, k2, dir) =>
        {
            if (Input.GetKey(k1))
            {
                dir = -1;
                if (Input.GetKeyDown(k1))
                {
                    MultiKey++;
                }
                if (MultiKey == 1)
                {
                    firstKey = -1;
                }
            }
            if (Input.GetKey(k2))
            {
                dir = 1;
                if (Input.GetKeyDown(k2))
                {
                    MultiKey++;
                }
                if (MultiKey == 1)
                {
                    firstKey = 1;
                }
            }
            if (MultiKey == 2)
            {
                dir = -firstKey;
            }
            if (Input.GetKeyUp(k1) || Input.GetKeyUp(k2))
            {
                MultiKey--;
            }
            if (MultiKey == 0)
            {
                firstKey = 0;
            }

            return dir;

        };

        float h = action(KeyCode.LeftArrow, KeyCode.RightArrow, 0);
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v);
        transform.position += dir * speed * Time.deltaTime;
        if (dir != new Vector3(0, 0, 0))
            animator.SetBool("Move", true);
        else
            animator.SetBool("Move", false);
    }
}

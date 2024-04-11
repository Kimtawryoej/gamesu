using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerBoom : MonoBehaviour
{
    Animator anim;
    public GameObject[] g = new GameObject[3];
    public static PlayerBoom instance;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        StartCoroutine(Rang());
    }

    // Update is called once per frame
    IEnumerator Rang()
    {
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Move") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(g[0], new Vector3(UnityEngine.Random.Range(-8.16f, 8.16f), UnityEngine.Random.Range(-4.36f, 4.36f), 0), Quaternion.identity);
        }
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Move") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
        gameObject.SetActive(false);
    }
}

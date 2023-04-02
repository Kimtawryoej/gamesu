using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerskillBoom : MonoBehaviour
{
    public static PlayerskillBoom Instance;
    Animator anim;
    AllMonster [] attackMonster;
    GameObject particle;
    void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Boom());   
    }
    IEnumerator Boom()
    {
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Move") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        attackMonster = FindObjectsOfType<AllMonster>();
        foreach(var m in attackMonster)
        {
            m.Hp-=1;
            Debug.Log("¥Í¿Ω");
        }
        gameObject.SetActive(false);
        //Instantiate()
    }
}

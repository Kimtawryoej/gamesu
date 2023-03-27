using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : SingleTone<Boom>
{
    Animator ani;
    public GameObject[] g;
    List<GameObject> i  = new List<GameObject>();
    public GameObject back;
    // Start is called before the first frame update
    private void Awake()
    {
        ani = GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(bbang());
    }

   IEnumerator bbang()
    {
        yield return new WaitUntil(() => ani.GetCurrentAnimatorStateInfo(0).IsName("Boom") && ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        back.SetActive(true);
        Debug.Log("WWW");
        camer.Instance.animator.SetBool("Move",true);
        g = Object.FindObjectsOfType<GameObject>();
        foreach(var a in g)
        {
            if(a.gameObject.layer == 7)
               i.Add(a);
        }
        foreach (var g in i)
            if (g.CompareTag("Monster"))
                Monster.Instance.HpManager(1);
        yield return new WaitForSeconds(1);
        camer.Instance.animator.SetBool("Move", false);
        gameObject.SetActive(false);
        back.SetActive(false);
    }
}

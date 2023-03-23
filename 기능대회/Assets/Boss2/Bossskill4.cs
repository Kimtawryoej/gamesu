using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossskill4 : Unit
{
    Animator anim;
    public static Bossskill4 instance;
    public static float damage = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        type = UnitType.Enemy;
        if (gameObject.CompareTag("BossSkill4"))
            gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if(gameObject.CompareTag("BossSkill4"))
            StartCoroutine(Fasle());
    }
    IEnumerator Fasle()
    {
        yield return null;
        transform.position = BossRang.Instance.transform.position;
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("주먹") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        Debug.Log("@");
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("닿음");
        damage = 3;
        TriggerManager.instance.GAM(gameObject);
        TriggerManager.instance.OnTriggerEnter2D(collision);//플레이어 총알 사라지게 하기
    }
}

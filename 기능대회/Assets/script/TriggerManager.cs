using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.ParticleSystem;

public class TriggerManager : MonsterHpManager
{
    public GameObject Partical;
    public static TriggerManager instance;
    public Dictionary<GameObject, float> MonsterHp = new Dictionary<GameObject, float>();
    public Dictionary<GameObject, float> SaveMonsterHp = new Dictionary<GameObject, float>();
    public Dictionary<GameObject, float> MonsterAttack = new Dictionary<GameObject, float>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MonsterHp = new Dictionary<GameObject, float>
        {
            {GameObject.FindWithTag("Normal"),MonsterHpManager.instance.normal1},
            {GameObject.FindWithTag("meteor"),MonsterHpManager.instance.meteor},
            {GameObject.FindWithTag("boss"),MonsterHpManager.instance.boss}
        };


        SaveMonsterHp = new Dictionary<GameObject, float>
        {
            {GameObject.FindWithTag("Normal"),MonsterHpManager.instance.normal1},
            {GameObject.FindWithTag("meteor"),MonsterHpManager.instance.meteor},
            {GameObject.FindWithTag("boss"),MonsterHpManager.instance.boss}
        };

        MonsterAttack = new Dictionary<GameObject, float>
        {
            {GameObject.Find("MonsterBullet"),AttackManager.instance.NormalMonsterAttack},
            {GameObject.FindWithTag("Normal"),1},
            {GameObject.FindWithTag("meteor"),AttackManager.instance.Meteor},
            {GameObject.FindWithTag("BossBullet"),AttackManager.instance.BossAttack}
        };
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            foreach (var key in MonsterHp)
                if (key.Key.gameObject.tag == collision.gameObject.tag)
                {
                    Debug.Log("!");
                    MonsterHp[key.Key] -= AttackManager.instance.PlayerAttack;
                    Debug.Log(MonsterHp[key.Key]);
                    Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
                    if (MonsterHp[key.Key] <= 0 && key.Key != GameObject.FindWithTag("boss"))
                    {
                        foreach (var key2 in SaveMonsterHp)
                            if(key.Key == key2.Key)
                            {
                                MonsterHp[key.Key] = key2.Value;
                                Debug.Log(MonsterHp[key.Key]);
                            }
                        Debug.Log("Á×À½");
                        GameManager.instance.score += 20;
                        PlayerPrefs.SetInt("score", GameManager.instance.score);
                        ItemManager.Instance.c = Random.Range(0, 5);
                        Instantiate(ItemManager.Instance.Key[ItemManager.Instance.c].gameObject, collision.gameObject.transform.position, Quaternion.identity);
                        Debug.Log(ItemManager.Instance.Key[ItemManager.Instance.c]);
                        Destroy(collision.gameObject);
                    }
                    break;
                }
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
            Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("MonsterBullet") && collision.gameObject.layer != 3)
            Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Boom"))
            Destroy(collision.gameObject);
    }
    public void Instaite()
    {
        ItemManager.Instance.c = Random.Range(0, 5);
        Instantiate(ItemManager.Instance.Key[ItemManager.Instance.c].gameObject, Boss.instance.gameObject.transform.position, Quaternion.identity);
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TriggerManager : MonoBehaviour
{
    public GameObject Partical;
    public static TriggerManager instance;
    public Dictionary<GameObject, float> MonsterHp = new Dictionary<GameObject, float>();
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
                    Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90,0,0));
                    break;
                }
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
            Destroy(collision.gameObject);

        //if (collision.gameObject.CompareTag("MonsterBullet") && collision.gameObject.layer != 3)
        //    Destroy(collision.gameObject);


    }
}




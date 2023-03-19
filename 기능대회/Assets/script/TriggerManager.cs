using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.ParticleSystem;

public class TriggerManager : Unit
{
    public GameObject Partical;
    public static TriggerManager instance;    
    public Collider2D monsterdata;
    private void Awake()
    {
        
        instance = this;
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Normal"))
        {
            monsterdata = collision;
            Monster.Instance.ChangeHp(-AttackManager.instance.PlayerAttack);
            Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        }
        if (collision.gameObject.CompareTag("meteor"))
        {
            monsterdata = collision;
            Meteor.Instance.ChangeHp(-AttackManager.instance.PlayerAttack);
            Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        }
        if (collision.gameObject.CompareTag("boss"))
        {
            monsterdata = collision;
            Boss.instance.ChangeHp(-AttackManager.instance.PlayerAttack);
            Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        }
        if (collision.gameObject.CompareTag("Player") && Bullet.instance.type != UnitType.Player)
        {
            monsterdata = collision;
            Player.Instance.ChangeHp(-1);
            Camera.Instance.Animation.SetBool("Move", true);
            Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
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




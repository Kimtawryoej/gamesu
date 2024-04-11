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
    GameObject g;
    private void Awake()
    {
        
        instance = this;
    }
    void  Trigger(Collider2D collision, GameObject gam)
    {
        if (gam.layer == 9)
        {
            if (collision.gameObject.CompareTag("Normal") || collision.gameObject.CompareTag("RaserMonster"))
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
        }
        if (gam.layer == 3)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                monsterdata = collision;
                Debug.Log("¤Ä¤Ó‘÷¤¡");
                Player.Instance.ChangeHp(-1 * Bossskill4.damage);
                Camera.Instance.Animation.SetBool("Move", true);
                Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            }
        }
    }
  public  GameObject GAM(GameObject Gam)
    {
        g = Gam;
        return g;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        Trigger(collision,g);
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




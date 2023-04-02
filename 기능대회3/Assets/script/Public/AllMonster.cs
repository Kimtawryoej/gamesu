using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class AllMonster : Untill
{
    public static AllMonster Instance;
    public GameObject particle;
    public GameObject Dieparticle;
    public GameObject Bossparticle;
    float MaxHp;
    
    private void Awake()
    {
        Instance = this;
        MaxHp = Hp;
    }
    public override void Die()
    {

        GameManager.Instance.ITEMS.Add(Instantiate(ITEM.Instance.items[Random.Range(0, 4)], transform.position, Quaternion.identity));
        Debug.Log(GameManager.Instance.ITEMS.Count);
        GameManager.Instance.ALLMonster = new AllMonster[0];
        GameManager.Instance.position.Clear();
        GameManager.Instance.Saveposition = "¾øÀ½";
        if(!gameObject.CompareTag("Boss"))
            Destroy(gameObject);
        if (gameObject.CompareTag("Boss"))
            Bos.Instance.gameObject.SetActive(false);
        GameManager.Instance.table.Score += 100;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            HpManager(MaxHp);
            if(Hp > 1)
                Instantiate(particle, transform.position, Quaternion.identity);
            else if(Hp < 1)
            {
                Instantiate(Dieparticle, transform.position, Quaternion.identity);
                if(gameObject.CompareTag("Boss"))
                {
                    Camera.Instance.gameObject.GetComponent<Animator>().enabled = true;
                    Instantiate(Bossparticle, transform.position, Quaternion.identity);
                }
            }
        }
    }
}

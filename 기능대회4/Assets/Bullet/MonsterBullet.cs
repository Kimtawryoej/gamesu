using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet :Unit
{
   Bullet bulllet = new Bullet();
    public override void DieManager()
    {
        base.DieManager();
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Hp = 3;
        Attack = -0.5f;
        StartCoroutine(bulllet.Des(gameObject));
        bulllet.SpeedGet = 15;
        if (Monster.Instance.SaveCount2== 1 || Monster.Instance.SaveCount2 == 3)
        {
            transform.LookAt(Player.Instance.transform);
            //Debug.Log(SaveCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bulllet.Lookattransform(transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        TriggerManager.Instance.CheackGameObject(gameObject);
        TriggerManager.Instance.OnTriggerEnter(other);
        //if (gameObject.tag != other.gameObject.tag)
        //    Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Unit
{
    Bullet  Bullet   = new Bullet();
    public override void DieManager()
    {
        base.DieManager();
        Destroy(gameObject);
    }
    void Start()
    {
        Hp = 1;
        Attack = -0.5f;
        Bullet.SpeedGet = -15;
        StartCoroutine(Bullet.Des(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        Bullet.trans(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerManager.Instance.CheackGameObject(gameObject);
        TriggerManager.Instance.OnTriggerEnter(other);
        if(gameObject.tag != other.gameObject.tag && !other.gameObject.CompareTag("MonsterBullet"))
            Destroy(gameObject);
    }
}

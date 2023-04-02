using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metor : Unit
{

    float time;
    Strttackj strttackj = new Strttackj();
    Bullet Manager = new Bullet();
    public override void DieManager()
    {
        base.DieManager();
        Destroy(gameObject);
    }
    private void Start()
    {
        Hp = 3;
        Attack = -0.5f;
        StartCoroutine(Rang());
    }
    private void Update()
    {
        Manager.trans(transform);
    }
    IEnumerator Rang()
    {

        Manager.SpeedGet = 0;
        Strttackj.Instance.Line(transform.position, transform.position + new Vector3(100, 0, 0));
        yield return new WaitForSeconds(3);
        Strttackj.Instance.lineRenderer.GetComponent<LineRenderer>().enabled = false;
        Manager.SpeedGet = 30;
    }
    private void OnTriggerEnter(Collider other)
    {
        TriggerManager.Instance.CheackGameObject(gameObject);
        if(!other.gameObject.CompareTag("PlayerBullet"))
            TriggerManager.Instance.OnTriggerEnter(other);
    }
}

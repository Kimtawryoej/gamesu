using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MonsterAttack = 1;
    public GameObject Bullet;
    public Vector3 position;
    public static Monster Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StartCoroutine(move());
        StartCoroutine(stop());
        StartCoroutine(Bullet2());
        Debug.Log("»ý¼º");
    }
    public void FixedUpdate()
    {
        position = transform.position;
        transform.Translate(0, -1 * Time.fixedDeltaTime, 0);
        if (TriggerManager.instance.MonsterHp[GameObject.FindWithTag("Normal")] <= 0)
        {
            TriggerManager.instance.MonsterHp[GameObject.FindWithTag("Normal")] = 5;
            Debug.Log("Á×À½");
            Destroy(gameObject);
        }
    }

    IEnumerator move()
    {


        transform.ELUR(Player.Instance.transform.position);
        yield return null;
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    IEnumerator Bullet2()
    {
        WaitForSeconds wait = new WaitForSeconds(2.5f);
        while (true)
        {
            yield return wait;
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

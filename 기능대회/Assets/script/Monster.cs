using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

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
        Debug.Log("생성");
    }
    public void FixedUpdate()
    {
        position = transform.position;
        transform.Translate(0, -1 * Time.fixedDeltaTime, 0);
    }

    IEnumerator move()
    {


        transform.ELUR(Player.Instance.transform.position);
        yield return null;
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(15);
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
        if (gameObject.CompareTag("PlayerBullet"))
            TriggerManager.instance.OnTriggerEnter2D(collision);//플레이어 총알 사라지게 하기
    }
}

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
        transform.Translate(0, -3.5f * Time.fixedDeltaTime, 0);
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
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true)
        {
            yield return wait;

            for (int i = 0; i < 7; i++)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 60));
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("Boom"))
            TriggerManager.instance.OnTriggerEnter2D(collision);//플레이어 총알 사라지게 하기
    }
}

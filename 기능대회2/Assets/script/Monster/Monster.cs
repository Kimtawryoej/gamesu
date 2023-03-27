using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : Unit
{
    public GameObject Manager;
    public static Monster Instance;
    public GameObject MonsterBullet;
    public GameObject Laser;
    public int Pattern;
    int speed = 8;
    int Item;
    public override void DIE()
    {
        Item = Random.Range(0, 4);
        ItemManager.Instance.ITEM.Add(Instantiate(ItemManager.Instance.Item[Item], transform.position, Quaternion.identity));
        if (GameManager.Instance.find == gameObject)
        {
            GameManager.Instance.Monsters = new Monster[0];
            GameManager.Instance.Length.Clear();
            GameManager.Instance.find = null;
        }
        Destroy(gameObject);
        TriggerManager.Instance.table.scroe += 30f;

    }
    private void Awake()
    {
        if (!gameObject.CompareTag("Boss"))
        {
            Manager = GameObject.Find("MonsterManager");
            transform.SetParent(Manager.transform);
            Instance = this;
            Pattern = Random.Range(0, 3);

        }
    }
    void Start()
    {
        if (!gameObject.CompareTag("Boss"))
        {
            Hp = 10;
            MaxHp = 10;
            Fuel = 10;
            type = Type.player;
            StartCoroutine(Die());
            StartCoroutine(Bullet());
            if (gameObject.layer == 8)
            {
                HpManager(1);
                gameObject.layer = 7;
            }
            transform.LookAt(Player.instance.transform);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameObject.CompareTag("Boss"))
            transform.position += transform.forward * speed * Time.deltaTime;
    }
    IEnumerator Bullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            switch (Pattern)
            {
                case 0:
                    Instantiate(MonsterBullet, transform.position, Quaternion.identity);
                    break;
                case 1:
                    for (int i = 1; i < 18; i++)
                    {
                        Instantiate(MonsterBullet, transform.position, Quaternion.Euler(0, i * 20, 0));
                        Instantiate(MonsterBullet, transform.position, Quaternion.Euler(i * 20, 0, 0));
                        Instantiate(MonsterBullet, transform.position, Quaternion.Euler(0, 0, i * 20));
                    }
                    break;
                case 2:
                    Instantiate(Laser, transform.position, Quaternion.identity);
                    speed = 0;
                    yield return new WaitForSeconds(7);
                    Destroy(gameObject);
                    break;

            };
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!gameObject.CompareTag("Boss"))
        {

            if (collision.gameObject.CompareTag("PlayerBullet") && Hp != 0)
            {
                HpManager(1);
                Instantiate(TriggerManager.Instance.partical, transform.position, Quaternion.identity);
            }
        }
    }
}

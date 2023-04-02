using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrpt : Untill
{
    public static Scrpt Instance;
    float H;
    float V;
    Vector3 dir;
    float speed = 15;
    public static float Lv = 1;
    [SerializeField]
    private GameObject BULLET;
    [SerializeField]
    List<GameObject> Gun;
    [SerializeField]
    List<GameObject> SaveGun;
    float SlowTime;
    public bool neverDie;
    public static bool DicCheck = false;
    public Animator ani;
    public override void Die()
    {
        gameObject.SetActive(false);
        DicCheck = true;
        base.Die();
    }
    void Awake()
    {
        Instance = this;
        Hp = 150;
        Fuel = 60;
        Attack = 1;
    }
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        FuelManager(Fuel);
        Move();
        Bullet();
        if (transform.position.y != -17.28f)
            dir = new Vector3(H, V);
        if (transform.position.y == -17.28f)
            dir = new Vector3(H, 0, V);
        transform.position += dir * speed * Time.deltaTime;
    }


    void Bullet()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SlowTime += Time.deltaTime;
            if (SlowTime > 0.09f)
            {
                Gun.Clear();
                for (int i = 0; i < Lv; i++)
                    Gun.Add(SaveGun[i]);
                foreach (GameObject a in Gun)
                {
                    Instantiate(BULLET, a.transform.position, Quaternion.Euler(0, 90, -90.822f));
                    SlowTime = 0;

                }
            }
        }
    }
    private void Move()
    {
        H = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
            H = -1;

        if (Input.GetKey(KeyCode.RightArrow))
            H = 1;
        V = Input.GetAxis("Vertical");
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("MonsterBullet") && neverDie)
        {
            HpManager(Hp);
        }
        if (collision.gameObject.layer == 3)
        {
            foreach (var a in ITEM.Instance.ITEMS)
            {
                if (collision.gameObject.tag == a.Key)
                {
                    if (ITEM.Instance.Saveitems.Count < 3)
                    {
                        ITEM.Instance.Saveitems.Add(collision.gameObject.name);
                        a.Value();
                    }
                    Destroy(collision.gameObject);

                }
            }
        }
    }
}

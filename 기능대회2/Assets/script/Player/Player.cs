using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Unit
{
    public static Player instance;
    public float Attack = 1;
    public int LV = 1;
    float h;
    float V;
    int speed = 5;
    float time;
    public Animator animator;
    public GameObject Bullet;
    public List<GameObject> Gun;
    public List<GameObject> GunList;
    GameObject list;
    float Tim;
    float stage2Time = 0; // 스테이지2에서는 시간이 지나도 이동 방법이 바뀌지 않게 조건을 늘림
    Vector3 dir;
    //public bool LVUp;
    int key;
    public override void DIE()
    {
        Debug.Log("죽음");
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        instance = this;
    }
 
    public void OnEnable()
    {
        Hp = 150;
        MaxHp = 150;
        Fuel = 60;
        type = Type.player;
        Tim = 0;
    }
    void Update()
    {
        Tim += Time.deltaTime;
        bullet();
        fuel(Fuel);
        Move(out h, out V);
        if (Tim < 60 + stage2Time)
        { dir = new Vector3(h, V, 0); transform.position += dir*0.07f; }
        else if (Tim >= 60 && SceneManager.GetActiveScene().name == "SampleScene")
        { dir = new Vector3(h, 0, V); transform.position += dir * 0.07f; }
        else if (Tim >= 60 && SceneManager.GetActiveScene().name == "Stage2")
        { dir = new Vector3(h, V, 0); transform.position += dir * 0.07f; }

    }
   
    public void LevelUp()
    {
        LV = Mathf.Clamp(LV + 1, 1, 4);

        Gun.Clear();
        Gun.Add(gameObject);
        for (int i = 1; i < LV; i++)
        {
            Gun.Add(GunList[i - 1]);
        }
    }

    void bullet()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && time > 0.1f)
        {
            for (int i = 0; i < Gun.Count; i++)
            {
                Instantiate(Bullet, Gun[i].transform.position, Quaternion.Euler(0, 90, 90));
            }
            time = 0;
        }
    }
    void Move(out float H, out float V)
    {
        H = 0;
        animator.SetBool("Idle", true);
        transform.eulerAngles = new Vector3(180, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            H = -1;
            animator.SetBool("Idle", false);
            transform.eulerAngles = new Vector3(180, 0, 0);
            for (int i = 0; i < 3; i++)
            {
                transform.rotation = Quaternion.Euler(180, 0, -i * 10);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            H = 1;
            animator.SetBool("Idle", false);
            transform.eulerAngles = new Vector3(180, 0, 0);
            for (int i = 0; i < 3; i++)
            {
                transform.eulerAngles = new Vector3(180, 0, i * 10);
            }
        }
        V = Input.GetAxis("Vertical");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9)
        {
            HpManager(Attack);
            Instantiate(TriggerManager.Instance.partical, transform.position, Quaternion.identity);
        }
        foreach (var a in ItemManager.Instance.Items)
        {
            if (collision.gameObject.tag == a.Key)
            {
                a.Value();
                ItemManager.Instance.ITEM.Clear();
                Destroy(collision.gameObject);

            }
        }
    }
}

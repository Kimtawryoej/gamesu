using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public static Player Instance;
    public int LV = 1;
    float h;
    float V;
    int speed = 5;
    float time;
    public Animator animator;
    public GameObject Bullet;
    public List<GameObject> Gun;
    public List<GameObject> GunList;
    Dictionary<int, GameObject> GunDict = new Dictionary<int, GameObject>();
    public override void DIE()
    {
        Debug.Log("Á×À½");
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GunDict = new Dictionary<int, GameObject>
        {
            { 0,GunList[0]},
            { 1,GunList[1]},
            { 2,GunList[2]},

        };
        Hp = 10;
        MaxHp = 10;
        Fuel = 20;
        type = Type.player;
    }
    void Update()
    {
        bullet();
        Move(out h, out V);
        Vector3 dir = new Vector3(h, 0, 0);
        transform.position += dir * 10 * Time.deltaTime;
        for (int i = 1; i < LV; i++)
        {
            Debug.Log(i);
            if (i != 1 && Gun.Count <= 4)
                Gun.Add(GunDict[i - 2]);
        
        }

    }

    void bullet()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && time > 0.4f)
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
}

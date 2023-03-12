using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameObject GUN;
    public GameObject[] GUN2 = new GameObject[2];
    public List<GameObject> gameObjects = new List<GameObject>();
    public static float LV = 1;
    public GameObject Partical;
    public float[] HPMANAGER = new float[3];
    HpManager hpManager = new HpManager();
    public GameObject Bullet;
    public float MaxHp = 10;
    public static Player Instance { get; private set; }
   public  int speed = 5;
    public float MaxX, MaxY, MinX, MinY;
    float MultiKey;
    float firstKey;
    float T = 0;
    public bool StopTrigger = true;
    private void Awake()
    {
        Instance = this;
        hpManager.action(10, 10, 0, 0);
        hpManager.MaxTime = 10;
        hpManager.MaxHp = 10;
        //if (SceneManager.GetActiveScene().name != "Shop")
        //    DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(GUN3());
        StartCoroutine(GUN4());
        hpManager.Start();
        hpManager.action(10, 10, 0, 0);

    }
    // Update is called once per frame
    void Update()
    {

        Func<KeyCode, KeyCode, float, float> action = (k1, k2, dir) =>
        {
            if (Input.GetKey(k1))
            {
                dir = -1;
                if (Input.GetKeyDown(k1))
                {
                    MultiKey++;
                }
                if (MultiKey == 1)
                {
                    firstKey = -1;
                }
            }
            if (Input.GetKey(k2))
            {
                dir = 1;
                if (Input.GetKeyDown(k2))
                {
                    MultiKey++;
                }
                if (MultiKey == 1)
                {
                    firstKey = 1;
                }
            }
            if (MultiKey == 2)
            {
                dir = -firstKey;
            }
            if (Input.GetKeyUp(k1) || Input.GetKeyUp(k2))
            {
                MultiKey--;
            }
            if (MultiKey == 0)
            {
                firstKey = 0;
            }

            return dir;

        };

        if (Input.GetKey(KeyCode.Space))
        {

            if (T > 0.2f)
                T = 0;
            if (T == 0)
            {
                for (int i = 0; i < LV; i++)
                {
                    Instantiate(Bullet, gameObjects[i].transform.position, Quaternion.Euler(0, 0, 0));
                }
            }
            T += Time.deltaTime;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
            T = 0;
        float h = action(KeyCode.LeftArrow, KeyCode.RightArrow, 0);
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v);
        transform.position += dir * speed * Time.deltaTime;
        float x = Mathf.Clamp(transform.position.x, MinX, MaxX);
        float y = Mathf.Clamp(transform.position.y, MinY, MaxY);
        transform.position = new Vector3(x, y);
        if (SceneManager.GetActiveScene().name != "Shop")
            hpManager.action(HPMANAGER[0], HPMANAGER[1], 0, 0);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (StopTrigger == true)
        {
            //hpManager.OnTriggerEnter2D(collision);
            if (collision.gameObject.layer == 3)
            {
                foreach (var key in TriggerManager.instance.MonsterAttack)
                {
                    if (key.Key.gameObject.tag == collision.gameObject.tag)
                    {
                        Player.Instance.HPMANAGER[0] -= key.Value;
                        Instantiate(Partical, collision.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
                    }
                }
            }
        }
        if (collision.gameObject.layer == 7)
        {
            ItemManager.Instance.value[ItemManager.Instance.c]();
            Debug.Log(ItemManager.Instance.value[ItemManager.Instance.c]);
            Destroy(collision.gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Raser"))
            Player.Instance.HPMANAGER[0] -= AttackManager.instance.Raser;
    }

    IEnumerator GUN3()
    {
        yield return new WaitUntil(() => LV == 2);
        GUN2[0] = Instantiate(GUN, transform.position + new Vector3(-1.5f, 0, 0), Quaternion.Euler(0, 0, 0));
        GUN2[0].transform.SetParent(transform);
        gameObjects.Add(GUN2[0]);
    }
    IEnumerator GUN4()
    {
        yield return new WaitUntil(() => LV == 3);
        Debug.Log("·¹º§¾÷");
        if (GUN2[0] == null)
        {
            GUN2[0] = Instantiate(GUN, transform.position + new Vector3(-1.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            GUN2[0].transform.SetParent(transform);
            gameObjects.Add(GUN2[0]);
        }
        GUN2[1] = Instantiate(GUN, transform.position + new Vector3(1.5f, 0, 0), Quaternion.Euler(0, 0, 0));
        GUN2[1].transform.SetParent(transform);
        gameObjects.Add(GUN2[1]);
    }
}
public class HpManager : MonoBehaviour
{
    public float MaxHp = 10;
    public float MaxTime;
    public static HpManager Instance;
    public void Start()
    {
        Instance = this;
    }
    public Action<float, float, float, float> action = (hp, fuel, t, t2) =>
    {
        if (hp <= 0 || fuel <= 0)
        {
            Player.Instance.gameObject.SetActive(false);
        }
        t += Time.deltaTime;
        t2 = t;
        fuel -= Time.deltaTime * 0.2f;
        Player.Instance.HPMANAGER[0] = hp;
        Player.Instance.HPMANAGER[1] = fuel;


    };
}


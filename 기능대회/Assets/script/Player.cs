using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Unit
{
    public Animator animator;
    public GameObject GUN;
    public GameObject[] GUN2 = new GameObject[2];
    public List<GameObject> gameObjects = new List<GameObject>();
    public static float LV = 1;
    public float[] HPMANAGER = new float[3];
    HpManager hpManager = new HpManager();
    public GameObject Bullet;
    public static Player Instance { get; private set; }
    public float MaxX, MaxY, MinX, MinY;
    float T = 0;
    public bool StopTrigger = true;
    public GameObject partical;
    public override void OnDie(Collider2D collision)
    {
       gameObject.SetActive(false);
        Instantiate(partical, collision.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        // 죽었을때 이팩트
        // 죽었으때 사운드
    }
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        //animator.SetBool("연출", false);
        hp = 10;
        maxHp = 10;
        hpManager.action(hp, 10, 0, 0);
        hpManager.MaxTime = 10;
        hpManager.MaxHp = 10;
        //if (SceneManager.GetActiveScene().name != "Shop")
        //    DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        StartCoroutine(GUN3());
        StartCoroutine(GUN4());
        StartCoroutine(die());
        hpManager.Start();
        hpManager.action(10, 10, 0, 0);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            if (T > 0.06f)
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
        float x = Mathf.Clamp(transform.position.x, MinX, MaxX);
        float y = Mathf.Clamp(transform.position.y, MinY, MaxY);
        transform.position = new Vector3(x, y);
        if (SceneManager.GetActiveScene().name != "Shop")
            hpManager.action(HPMANAGER[0], HPMANAGER[1], 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            ItemManager.Instance.item[ItemManager.Instance.Key[a]]();
            Debug.Log(a);
            Destroy(collision.gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Raser"))
            Player.Instance.HPMANAGER[0] -= AttackManager.instance.Raser;
    }

    IEnumerator die()
    {
        yield return new WaitUntil(() => hp <= 0);
        gameObject.SetActive(false);
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
        Debug.Log("레벨업");
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


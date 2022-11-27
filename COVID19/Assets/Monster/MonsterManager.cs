using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    public GameObject prefab2;
    public GameObject prefab;
    public SpriteRenderer render;
    Collider2D Collider;
    public int hp = 1;
    Rigidbody2D Rigidbody;
     int random = 5;
     int random2 = 4;
    public int rand;



    void Awake()
    {
        Instance = this;
        Collider = GetComponent<Collider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -1 * Time.fixedDeltaTime, 0));
        if (hp < 0 || transform.position.y < -10f)
        {
            if (hp < 0)
            {
                Public.Instance.score += 100;
               rand = UnityEngine.Random.Range(1, random);
                Debug.Log("rand:"+rand);
              if (rand == random2)
              {
                    Public.Instance.leavel++;
                }
            }
            transform.position = Vector3.zero;
            MonsterObjectPool.Instance.Disappear(prefab);
            if (gameObject.CompareTag("red blood") && rand == random2)
            {
                Public.Instance.pain--;
            }
            hp = 7;
        }
        Rigidbody.velocity = Vector3.zero; //������ ���ӵ��� 0���� ����� �ڷ� �з����°� ����
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet")) //�� gameObject�� ������ �� ����!!
        {
            hp -= 1;
            StartCoroutine(changecolor());
            Debug.Log(hp);

        }


    }

    public IEnumerator changecolor()
    {
        render.color = new Color(225, 0, 0);
        yield return new WaitForSeconds(0.2f);
        render.color = new Color(100, 100, 100);
        if (gameObject.CompareTag("red blood"))
        {
            render.color = new Color(100, 100, 100);
            yield return new WaitForSeconds(0.2f);
            render.color = new Color(255, 0, 0);
        }
        StopCoroutine(changecolor());
    }


    private IEnumerator monsterBullet()
    {
        while (true)
        {
            yield return null;
            ObjectPool.Instance.GetObject(prefab2, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1.25f, 5.25f));
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                StopCoroutine(monsterBullet());
                Debug.Log("�Ϳ�");
            }

        }
        //Vector3 direction = Player.Instance.transform.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //yield return new WaitForSeconds(1);
        //ObjectPool.Instance.GetObject(prefab2, transform.position, Quaternion.Euler(new Vector3(0, 0, angle + 90)));
    }
    private IEnumerator monsterBullet2()
    {
       while(true)
        {
            yield return null;
            if (SceneManager.GetActiveScene().name == "Stage2")
            {
                for (int i = 0; i < 12; i++)
                {
                    ObjectPool.Instance.GetObject(prefab2, transform.position + new Vector3(0, -5, 0), Quaternion.Euler(0, 0, 30 * i));
                }
            }
            yield return new WaitForSeconds(10);
        }
    }
    private void OnEnable() // ������ ��û ���� �ٸ��ڵ�� ���� �� ���� ����ȴ� �׷��� ���� transform.position�� �ޱ����� ������ �Ǽ� ��ǥ��0.0.0�� ������ ���� �߻簡 �Ǵ� ������ �߻� �ϱ⵵��
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            StartCoroutine(monsterBullet());
        }   
        StartCoroutine(monsterBullet2());
    }
}

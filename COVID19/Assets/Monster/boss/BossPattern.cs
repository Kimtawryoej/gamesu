using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPattern : MonoBehaviour
{
    public static BossPattern Instance;
    public int hp = 50;
    int random1 = 5;
    public int random;
    Collider2D Collider;
    int bull = 0;
    public GameObject prefab;


    int b = 0;
    private Dictionary<string, IEnumerator> pattern = new Dictionary<string, IEnumerator>();
    private void Start()
    {
        Collider = GetComponent<Collider2D>();
        Instance = this;
        gameObject.SetActive(false);

    }
    public void start()
    {
        gameObject.SetActive(true);
        pattern.Add("attack1", attack1());
        pattern.Add("attack2", attack2());
        pattern.Add("attack3", attack3());
        StartCoroutine(PatternControl_Cor());
    }

    private void FixedUpdate()
    {
        if (hp < 0)
        {
            Public.Instance.score += 1000;
            gameObject.SetActive(false);
            if(SceneManager.GetActiveScene().name == "Stage1")
            {
                SceneManager.LoadScene("Stage2");
            }
        }
    }
    public void rando()
    {


        switch (random)
        {
            case 1:
                StartCoroutine(pattern["attack1"]);
                Debug.Log("패턴1");
                break;

            case 2:
                StartCoroutine(pattern["attack2"]);
                Debug.Log("패턴2");
                break;

            case 3:
                StartCoroutine(pattern["attack1"]);
                StartCoroutine(pattern["attack2"]);
                Debug.Log("패턴3");
                break;

            case 4:
                StartCoroutine(pattern["attack3"]);
                Debug.Log("패턴4");
                break;
        }
    }




    private IEnumerator attack1()
    {
        for (float a = 0; a < 5; a += Time.deltaTime)
        {
            ObjectPool.Instance.GetObject(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }

    }


    private IEnumerator attack2()
    {
        for (float a = 0; a < 5; a += Time.deltaTime)
        {
            b += 3;
            for (int i = 0; i < 3; i++)
            {
                ObjectPool.Instance.GetObject(prefab, transform.position, Quaternion.Euler(0, 0, b * -2 * i));
                ObjectPool.Instance.GetObject(prefab, transform.position, Quaternion.Euler(0, 0, b * 2 * i));
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator attack3()
    {
        for (float a = 0; a < 5; a += Time.deltaTime)
        {
            for (int i = 0; i < 12; i++)
            {
                ObjectPool.Instance.GetObject(prefab, transform.position + new Vector3(0, -5, 0), Quaternion.Euler(0, 0, 30 * i));
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator PatternControl_Cor()
    {
        while (true)
        {
            random = UnityEngine.Random.Range(1, random1);
            if (pattern.ContainsKey("attack1"))
            {
                StopCoroutine(pattern["attack1"]);
            }
            if (pattern.ContainsKey("attack2"))
            {
                StopCoroutine(pattern["attack2"]);
            }
            if (pattern.ContainsKey("attack3"))
            {
                StopCoroutine(pattern["attack3"]);
            }
            rando();
            Debug.Log("attack");

            yield return new WaitForSeconds(5);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet")) //왜 gameObject를 쓰는지 꼭 이해!!
        {
            hp -= 1;
            Debug.Log(hp);
        }
    }






}

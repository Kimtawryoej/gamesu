using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.ParticleSystem;

[Serializable]
public class GameManager : MonoBehaviour
{
    public float MaxTime = 30;
    public float time;
    public static GameManager instance;
    public static float coin;
    public bool Bool = true;
    public float T;
    public bool COlor;
    public int score;
    public GameObject[] AttackRang = new GameObject[1];

    private void Awake()
    {
        instance = this;
        COlor = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !Boss.instance.gameObject.activeSelf)
        {
            Time.timeScale = 3;
            Player.Instance.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            Time.timeScale = 1;
            Player.Instance.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        time += Time.deltaTime;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {

            if (time >= MaxTime)
            {
                Boss.instance.gameObject.SetActive(true);
                Bool = true;
            }
            if (Boss.instance.gameObject.activeSelf)
            {
                BossHpUi.instance.gameObject.SetActive(true);
                Map.speed = 0;
            }
            //else if (Bool && !Boss.instance.gameObject.activeSelf)
            //{
                
            //    Bool = false;
            //}
        }


    }

    public IEnumerator TI()
    {
        Player.Instance.animator.SetBool("Color", true);
        Player.Instance.StopTrigger = false;
        while (T > 0)
        {
            COlor = false;
            T -= Time.deltaTime;
            yield return null;
        }
        Player.Instance.StopTrigger = true;
        Player.Instance.animator.SetBool("Color", false);
        T = 0;
        COlor = true;
        yield return null;

    }

}

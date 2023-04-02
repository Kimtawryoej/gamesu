using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject[] g;
    public GameObject boss;
    void Start()
    {
        //StartCoroutine(dont());
    }

    IEnumerator dont()
    {
        yield return new WaitUntil(() => boss.GetComponent<AllMonster>().Hp == 0);
        g = FindObjectsOfType<GameObject>();
        foreach (var item in g)
        {
            if(item.name != "boss"&& !item.gameObject.CompareTag("PlayerBullet") && !item.gameObject.CompareTag("BossBullet"))
            {
                DontDestroyOnLoad(item.gameObject);
                item.gameObject.SetActive(false);
            }
        }
    }
}

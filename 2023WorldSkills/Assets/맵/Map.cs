using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[] planet = new GameObject[3];
    public GameObject FixedStar;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Instaite());
        StartCoroutine(Instaite2());
    }

    IEnumerator Instaite()
    {
        WaitForSeconds wait = new WaitForSeconds(7);
        while (true)
        {
            GameObject a = planet[Random.Range(0, 3)];
            Instantiate(a, new Vector3(Random.Range(-7.54f, 7.54f), 5.92f), Quaternion.identity);
            yield return wait;
        }
    }
    IEnumerator Instaite2()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            Instantiate(FixedStar, new Vector3(Random.Range(-7.54f, 7.54f), 5.92f), Quaternion.identity);
            yield return wait;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bos : MonoBehaviour
{
    public static Bos Instance;
    public float patteren = 0;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject Raser;
    [SerializeField]
    List<GameObject> positions = new List<GameObject>();
    [SerializeField]
    GameObject attackRang;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(SavePatteren());
        StartCoroutine(Patteren());
        StartCoroutine(Move());
    }
    private void Update()
    {
        transform.LookAt(Scrpt.Instance.transform);
    }
    IEnumerator Patteren()
    {
        while (true)
        {
            switch (patteren)
            {
                case 0:
                    yield return null;
                    for (int i = 0; i < 25; i++)
                    {

                        Instantiate(bullet, transform.position, Quaternion.Euler(0, i * 16, 0));
                        //yield return null;
                    }
                    yield return new WaitForSeconds(1);

                    break;
                case 1:
                    Chaging.Instance.gameObject.SetActive(true);
                    yield return new WaitForSeconds(8);
                    break;
                case 2:
                    Chaging.Instance.gameObject.SetActive(false);
                    Instantiate(Raser, new Vector3(Random.Range(-23.5f, 23.5f), -17.5f, Random.Range(-19.34f, 0.8f)), Quaternion.Euler(0, 0, 0));
                    Instantiate(Raser, new Vector3(Random.Range(-23.5f, 23.5f), -17.5f, Random.Range(-19.34f, 0.8f)), Quaternion.Euler(0, 90, 0));
                    yield return new WaitForSeconds(2.5f);
                    break;
                case 3:
                    AttackRang.Instance.gameObject.SetActive(true);
                    for (int i = 0; i < 25; i++)
                    {

                        Instantiate(bullet, transform.position, Quaternion.Euler(0, i * 16, 0));
                        //yield return null;
                    }
                    yield return new WaitForSeconds(6f);
                    for (int i = 0; i < 25; i++)
                    {

                        Instantiate(bullet, transform.position, Quaternion.Euler(0, i * 16, 0));
                        //yield return null;
                    }
                    break;
            }
            yield return null;
        }
    }


    IEnumerator SavePatteren()
    {
        WaitForSeconds wait = new WaitForSeconds(16);
        while (true)
        {

            yield return wait;
            if (patteren == 3)
                patteren = -1;
            patteren++;
        }
    }



    IEnumerator Move()
    {
        while (true)
        {
            Vector3 Bossposition = transform.position;
            Vector3 target = positions[Random.Range(0, 4)].transform.position;
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(Bossposition, target, i);
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }
    }
}

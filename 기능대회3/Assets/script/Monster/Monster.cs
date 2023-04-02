using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Monster Instance { get; private set; }
    Vector3 PlPosition;
    public GameObject prefsBullet;
    Dictionary<float, float> patterenAAttack = new Dictionary<float, float>();
    public float patteren;
    private void Awake()
    {
        Instance = this;
        patterenAAttack = new Dictionary<float, float>
        {
            {1,1},
            {2,14},
            {3, 14}

        };
    }
    void Start()
    {
        patteren = Random.Range(1, 4);
        transform.LookAt(Scrpt.Instance.transform.position);
        StartCoroutine(Bullet());
        StartCoroutine(des());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 7 * Time.deltaTime;
    }



    IEnumerator Bullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            switch (patteren)
            {
                case 1:
                    Instantiate(prefsBullet, transform.position, Quaternion.Euler(0, 0, 0));
                    break;
                case 2:
                    for (int i = 0; i < patterenAAttack[patteren]; i++)
                    {
                        Instantiate(prefsBullet, transform.position, Quaternion.Euler(i * 16, 0, 0));
                        Instantiate(prefsBullet, transform.position, Quaternion.Euler(0, i * 16, 0));
                        Instantiate(prefsBullet, transform.position, Quaternion.Euler(0, 0, i * 16));
                    }

                    break;
                case 3:
                    for (int i = 0; i < patterenAAttack[patteren]; i++)
                    {

                        Instantiate(prefsBullet, transform.position, Quaternion.Euler(0, i * 16, 0));

                    }
                    break;
            }

        }
    }

    IEnumerator des()
    {
        yield return new WaitUntil(() => transform.position.z < -10);
        Destroy(gameObject);
    }
}

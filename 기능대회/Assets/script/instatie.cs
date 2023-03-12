using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class instatie : MonoBehaviour
{
    public GameObject Monster2;
    public GameObject Meteor2;
    public GameObject skillRang;
    bool Bool;
    int random;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        Bool = true;


        StartCoroutine(Insta());
        StartCoroutine(Insta2());

    }

    // Update is called once per frame
    private void Update()
    {
        if (Boss.instance.gameObject.activeSelf)
        {
            StopAllCoroutines();
            Bool = false;
        }
        else if (!Boss.instance.gameObject.activeSelf && !Bool)
        {
            StartCoroutine(Insta());
            StartCoroutine(Insta2());
            Bool = true;
        }


    }
    IEnumerator Insta()
    {
        WaitForSeconds wait = new WaitForSeconds(5);
        while (true)
        {
            yield return wait;
            random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    Instantiate(Monster2, position = new Vector3(Random.Range(-8.61f, 8.61f), 6.21f, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Monster2, position = new Vector3(-10.93f, Random.Range(1, 4.21f), 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Monster2, position = new Vector3(10.93f, Random.Range(1, 4.21f), 0), Quaternion.identity);
                    break;
            }
            GameManager.instance.Bool = true;
        }
    }
    IEnumerator Insta2()
    {
        WaitForSeconds wait = new WaitForSeconds(10);
        while (true)
        {
            yield return wait;
            Instantiate(Meteor2, position = new Vector3(Random.Range(-5.48f, 5.48f), 6.21f, 0), Quaternion.identity);
            if(Meteor2.gameObject.activeSelf)
                Instantiate(skillRang, Meteor.Instance.transform.position + new Vector3(0, -6, 0), Quaternion.identity);
        }
    }
}

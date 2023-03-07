using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatie : MonoBehaviour
{
    public GameObject Monster2;
    public GameObject Meteor;
    bool Bool;
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
        if (!Boss.instance.gameObject.activeSelf && !Bool)
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
            Instantiate(Monster2, position = new Vector3(Random.Range(-5.48f, 5.48f), 6.21f, 0), Quaternion.identity);
            GameManager.instance.Bool = true;
        }
    }
    IEnumerator Insta2()
    {
        WaitForSeconds wait = new WaitForSeconds(15);
        while (true)
        {
            yield return wait;
            Instantiate(Meteor, position = new Vector3(Random.Range(-5.48f, 5.48f), 6.21f, 0), Quaternion.identity);
        }
    }
}

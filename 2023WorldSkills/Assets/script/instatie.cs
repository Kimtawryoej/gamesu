using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instatie : Singleton<instatie>
{
    public GameObject Monster2;
    public GameObject RaserMonster2;
    public GameObject[] Monster = new GameObject[2]; 
    public GameObject Meteor2;
    public GameObject skillRang;
    bool Bool2;
    int random;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        Bool2 = true;


        StartCoroutine(Insta());
        StartCoroutine(Insta2());

    }

    // Update is called once per frame
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Stage2" || SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Boss.instance.gameObject.activeSelf)
            {
                StopAllCoroutines();
                Bool2 = false;
            }
            else if (!Boss.instance.gameObject.activeSelf && !Bool2)
            {
                StartCoroutine(Insta());
                StartCoroutine(Insta2());
                Bool2 = true;
            }
        }


    }
   public  IEnumerator Insta()
    {
        WaitForSeconds wait = new WaitForSeconds(5);
        while (true)
        {
            yield return wait;
            random = Random.Range(0, 3);
            int random2 = Random.Range(0, 2);
            Debug.Log(random2);
            switch (random)
            {
                case 0:
                    Instantiate(Monster[random2], position = new Vector3(Random.Range(-8.61f, 8.61f), 6.21f, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Monster[random2], position = new Vector3(-10.93f, Random.Range(1, 4.21f), 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Monster[random2], position = new Vector3(10.93f, Random.Range(1, 4.21f), 0), Quaternion.identity);
                    break;
            }
        }
    }
    public IEnumerator Insta2()
    {
        WaitForSeconds wait = new WaitForSeconds(10);
        while (true)
        {
            yield return wait;
            GameObject A =  Instantiate(Meteor2, position = new Vector3(Random.Range(-5.48f, 5.48f), 6.21f, 0), Quaternion.identity);
            Debug.Log(A);
            if(A.activeSelf)
                Instantiate(skillRang, Meteor.Instance.transform.position + new Vector3(0, -6, 0), Quaternion.identity);
        }
    }
}

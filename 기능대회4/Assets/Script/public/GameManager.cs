using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject [] Monster = new GameObject[3];
    [SerializeField]
    GameObject Meteor;
    int change = 0;
    [SerializeField]
    Camera camer;
    void Start()
    {
        StartCoroutine(Create());
        StartCoroutine(Create2());
    }

    IEnumerator Create()
    {
        while(true)
        {
            yield return new WaitForSeconds(4);
            Instantiate(Monster[change],new Vector3(-1059.4f, 135.2f, Random.Range(-30.59f, 30.59f)),Quaternion.identity);
            yield return new WaitForSeconds(4);
            Instantiate(Monster[change], new Vector3(Random.Range(-1029.92f, -1015.95f), 135.2f, -28.71f), Quaternion.identity);
            yield return new WaitForSeconds(4);
            Instantiate(Monster[change], new Vector3(Random.Range(-1029.92f, -1015.95f), 135.2f, 28.71f), Quaternion.identity);
            if (change == 2)
                change = -1;
            change++;
        }
    }

    IEnumerator Create2()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            Instantiate(Meteor, new Vector3(-1059.4f, 135.2f, Random.Range(-30.59f, 30.59f)), Quaternion.identity);
        }
    }

    //IEnumerator Change()
    //{
    //    while (true)
    //}
}

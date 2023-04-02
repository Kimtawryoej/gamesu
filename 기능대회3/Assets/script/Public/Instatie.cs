using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instatie : MonoBehaviour
{
   public  GameObject prefsMonster;
    void Start()
    {
        StartCoroutine(Monster());
    }
    IEnumerator Monster()
    {
        yield return null; 
        while (!Bos.Instance.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(3);
            Instantiate(prefsMonster, new Vector3(Random.Range(-8.99f, 8.99f), Random.Range(-8.83f, 4.67f), 40), Quaternion.identity);
        }
    }
}

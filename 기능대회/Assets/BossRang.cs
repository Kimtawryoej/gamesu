using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRang : Singleton<BossRang>
{
   public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(Fasle());
    }
    IEnumerator Fasle()
    {
        yield return null;
        transform.position = new Vector3(Random.Range(-8.6f, 8.6f), Random.Range(-4.33f, 4.33f), 0);
        yield return new WaitForSeconds(3);
        Debug.Log("WWW");
        g.SetActive(true);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Connection<GameManager>
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(appear());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator appear()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            ObjectPool.Instance.objectpool(new Vector2(Random.Range(-8.11f, 8.11f), Random.Range(5.65f, 6)), prefab, Quaternion.identity);
        }
    }

}

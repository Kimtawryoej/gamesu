using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Connection<GameManager>
{
    public GameObject prefab;
    void Start()
    {
        StartCoroutine(Summons());

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Shield.Instance.gameObject.SetActive(true);
        }
        if (ExperienceManager.Instance.Lv == 2)
        {
            Midboss.Instance.gameObject.SetActive(true);
        }

    }
    public IEnumerator Summons()
    {
        WaitForSeconds wait = new WaitForSeconds(10);
        WaitForSeconds wai2 = new WaitForSeconds(3);
        while (true)
        {
            if (Midboss.Instance.sinho)
            {
                StopAllCoroutines();
            }
            yield return wait;
            ObjectPool.Instance.objectpool(prefab, new Vector3(Random.Range(-4.78f, 4.78f), Random.Range(5.91f, 6), 0), Quaternion.identity);
            if (Midboss.Instance.sinho)
            {
                StopAllCoroutines();
            }
        }
    }
}

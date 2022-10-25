using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField] GameObject MonsterPrefab;

    Queue<Monster> monsterpool = new Queue<Monster>();

    public Monster Getmonster()
    {
        Monster mon = null;
        if (monsterpool.Count > 0)
        {
            mon = monsterpool.Dequeue();
            mon.gameObject.SetActive(true);
        }
        else
        {
            mon = Instantiate(MonsterPrefab).GetComponent<Monster>();
            mon.transform.SetParent(transform);
        }
        return mon;
    }

    public void returnmonster(Monster mon)
    {
        mon.gameObject.SetActive(false);
        monsterpool.Enqueue(mon);
    }
}

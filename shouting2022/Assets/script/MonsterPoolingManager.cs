using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoolingManager : MonoBehaviour
{
    public static MonsterPoolingManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField] GameObject monsterPrefab;

    Queue<monster> monsterpool = new Queue<monster>();

    public monster Getmonster()
    {
        monster mon = null;
        if(monsterpool.Count > 0)
        {
            mon = monsterpool.Dequeue();
            mon.gameObject.SetActive(true);
        }
        else
        {
            mon = Instantiate(monsterPrefab).GetComponent<monster>();
            mon.transform.SetParent(transform);
        }
        return mon;
    }

    public void returnmonster(monster mon)
    {
        mon.gameObject.SetActive(false);
        monsterpool.Enqueue(mon);
    }

   
}

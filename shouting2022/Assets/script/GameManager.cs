using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;
    public static monster Instance;
    float curDelay;

    private void Update()
    {
        monste();
    }
    private void monste()
    {
        if (curDelay > 8f)
        {
            monster mon = MonsterPoolingManager.Instance.Getmonster();
            mon.transform.position = new Vector3(1, 6, 0);
            curDelay = 0;
        }
        curDelay += Time.deltaTime;
    }
}

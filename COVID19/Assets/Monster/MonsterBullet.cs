using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    private IEnumerator monsterBullet()
    {
        yield return  new WaitForSeconds(1);
        ObjectPool.Instance.GetObject(MonsterManager.Instance.prefab, MonsterManager.Instance.transform.position, Quaternion.identity);
    }
    private void OnEnable()
    {
        StartCoroutine(monsterBullet());
    }
}

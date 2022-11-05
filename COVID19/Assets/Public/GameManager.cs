using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    //MonsterManager monster = new MonsterManager();  // ���⿡�ٰ� �����ڸ� ����� ������ ���µ� transform���� �Ÿ� ����ҷ��� transform�� ���Ӻ信 �־�� �ϴµ� �����ڸ� �Ἥ �������� ���Ӻ信�� ���⶧����  MonsterManager monster �� �ƹ��͵� �ȵ��� �ȴ�.
    void Start()
    {
        
        StartCoroutine(Manager());
    }

    // Update is called once per frame
    public IEnumerator Manager()
    {
        while(true)
        {
        yield return new WaitForSeconds(3.0f);
        MonsterObjectPool.Instance.GetObject(prefab, new Vector3(Random.Range(-8.34f,8.34f), 5, 0), Quaternion.identity);
        }
    }
    
}

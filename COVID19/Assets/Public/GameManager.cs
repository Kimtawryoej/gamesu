using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    bool bol = true;
    
    //MonsterManager monster = new MonsterManager();  // 여기에다가 생성자를 만들면 만들어는 지는데 transform같은 거를 사용할려면 transform이 게임뷰에 있어야 하는데 생성자를 써서 가져오면 게임뷰에는 없기때문에  MonsterManager monster 에 아무것도 안들어가게 된다.
    void Start()
    {
        
        StartCoroutine(Manager());
        StartCoroutine(Manager2());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Public.Instance.score == 100 && bol == true)
        {
            BossPattern.Instance.start();
            bol = false;
        }
    }
    public IEnumerator Manager()
    {
        while(true)
        {
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                MonsterObjectPool.Instance.GetObject(prefab, new Vector3(Random.Range(-8.34f, 8.34f), 5, 0), Quaternion.identity);
                yield return new WaitForSeconds(3.0f);
            }
            if (SceneManager.GetActiveScene().name == "Stage2")
            {
                MonsterObjectPool.Instance.GetObject(prefab, new Vector3(Random.Range(-8.34f, 8.34f), 5, 0), Quaternion.identity);
                yield return new WaitForSeconds(7.0f);
            }

        }
    }
    public IEnumerator Manager2()
    {
        while(true)
        {
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                yield return new WaitForSeconds(5.0f);
                MonsterObjectPool.Instance.GetObject(prefab2, new Vector3(Random.Range(-8.34f, 8.34f), 5, 0), Quaternion.identity);
            }
            if (SceneManager.GetActiveScene().name == "Stage2")
            {
                yield return new WaitForSeconds(10.0f);
                MonsterObjectPool.Instance.GetObject(prefab2, new Vector3(Random.Range(-8.34f, 8.34f), 5, 0), Quaternion.identity);
            }
        }
    }
}

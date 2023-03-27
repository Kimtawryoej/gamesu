using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestory : SingleTone<DonDestory>
{
    public List<GameObject> gameObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dontdes());
    }

    IEnumerator dontdes()
    {
        yield return new WaitUntil(() => !Boss.instance.gameObject.activeSelf && Boss.instance.Hp == 0);
        foreach (var item in gameObjects)
        {
            DontDestroyOnLoad(item);
        }
    }
}

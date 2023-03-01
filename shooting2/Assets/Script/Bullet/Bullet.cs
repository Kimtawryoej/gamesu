using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : Connection<Bullet>
{
    // Start is called before the first frame update
    void OnEnable()
    {
        if (!Midboss.Instance.sinho && Boss.Instance.patternAttack == Boss.State.pattern)
        {
            StartCoroutine(monsterBullet());
        }
    }

    IEnumerator monsterBullet()
    {
        yield return null;
        transform.LookAt2D(Player.Instance.transform.position); //새로운 스크립트를 만들어 분리하니까 잘사용됨 한번에 monster에 넣어서 할려고 하니까 안됨
    }
}

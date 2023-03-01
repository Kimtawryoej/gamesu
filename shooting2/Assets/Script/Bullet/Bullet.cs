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
        transform.LookAt2D(Player.Instance.transform.position); //���ο� ��ũ��Ʈ�� ����� �и��ϴϱ� �߻��� �ѹ��� monster�� �־ �ҷ��� �ϴϱ� �ȵ�
    }
}

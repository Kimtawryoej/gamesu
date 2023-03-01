using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float returnPositionY = -5.4f;
    [SerializeField] private float speed = -1.1f;
   
    private void OnEnable()
    {
        StartCoroutine(LookPlayer_Cor());
    }
    void FixedUpdate()
    {
        if (transform.position.y > returnPositionY)
        {
            transform.Translate(0, speed * Time.fixedDeltaTime, 0);
        }
        else
        {
            ObjectPool.Instance.Return(gameObject);
        }
    }
    IEnumerator LookPlayer_Cor()
    {
        WaitForFixedUpdate fixedWait = new WaitForFixedUpdate(); //�̰� ������ ������ �Ʒ��� ����ɶ����� ��� Ŭ������ ����� ������ �̷��� �ѹ� ����� ��� ����ϰ� �Ѵ�.
        for (float t = 0; t < 2; t += Time.fixedDeltaTime)
        {
            transform.LookAt2D(Player.Instance.transform.position);
            yield return fixedWait;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletManager.Instance.OnCollisionEnter2D(collision);
    }
}

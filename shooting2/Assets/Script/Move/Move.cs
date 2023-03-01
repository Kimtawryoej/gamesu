using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move :Connection<Move>
{
    public float Speed = 0.4f;
    public void OnEnable()
    {
        if (gameObject.CompareTag("bullet"))
        {
            StartCoroutine(RETURN());
        }
        if (gameObject.CompareTag("MonsterBullet") || gameObject.CompareTag("Monster"))
        {
            StartCoroutine(RETURNMonster());
        }
    }
    public void FixedUpdate()
    {
        if(gameObject.CompareTag("MonsterBullet") && transform.localScale.y == -2.634f)
        {
            Speed = 1.5f;
        }
        transform.Translate(0, Speed * Time.fixedDeltaTime, 0);
    }
    IEnumerator RETURN()
    {
        yield return new WaitForSeconds(5);
        ObjectPool.Instance.RETURN(gameObject);
    }
    IEnumerator RETURNMonster()
    {
        yield return new WaitForSeconds(15);
        ObjectPool.Instance.RETURN(gameObject);
    }

    
}

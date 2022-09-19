using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullet2 : Bullet
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("monster"))
        {
            Debug.Log("f");
            //monster.Instance.Hit(); // 싱글톤 패턴은 게임 하나만 있는거를 쉽게 끌어올려고 쓰는건데 오브젝트 풀로 개수가 많아지면서 오류가남 
            collision.gameObject.GetComponent<monster>().Hit2();
            PoolingManager.Instance.ReturnBullet(key, this);
        }
    }
}
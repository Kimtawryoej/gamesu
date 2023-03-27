using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet : SingleTone<Bullet>
{
    public float speed;
    public static int attack = 0;
    GameObject parent;
    GameObject[] Playerbullet;

    private void Start()
    {
        StartCoroutine(destory());
        StartCoroutine(Die());
        if (!gameObject.CompareTag("BossBullet"))
        {
            StartCoroutine(slowlyDie());
            if (gameObject.layer == 7 && Monster.Instance.Pattern != 1)
                transform.LookAt(Player.instance.transform);
        }
    }
    // UpFdate is called once per frame
    void FixedUpdate()
    {
            if (gameObject.layer != 7)
                transform.Translate(0, speed * Time.fixedDeltaTime, 0);
        if (!gameObject.CompareTag("BossBullet"))
        {
            if (gameObject.layer == 7)
                transform.position += transform.forward * speed * Time.deltaTime;
            if (GameManager.Instance.find != null && gameObject.layer == 6)
            {
                Playerbullet = GameObject.FindGameObjectsWithTag("PlayerBullet");
                transform.position = Vector3.MoveTowards(gameObject.transform.position, GameManager.Instance.find.transform.position, Time.fixedDeltaTime * 15);
                /*transform.LookAt(GameManager.Instance.find.transform.position)*/
            }
        }
        //else if (GameManager.Instance.find != null && gameObject.layer == 6 && speed == 0)
        //{
        //    Destroy(gameObject);
        //    speed = 50;
        //}    
    }


    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    IEnumerator slowlyDie()
    {
        yield return new WaitUntil(() => GameManager.Instance.find != null && gameObject.layer == 6);
        speed = 0;
        yield return new WaitUntil(() => speed == 0);
        yield return new WaitForSeconds(1.3f);
        speed = 50;

    }
    IEnumerator destory()
    {
        yield return new WaitUntil(() => transform.position.z > 55);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {

    }
}

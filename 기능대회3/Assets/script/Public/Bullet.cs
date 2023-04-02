using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    float speed;
    string sinho;
    private void Awake()
    {
    }
    void Start()
    {
        if (gameObject.CompareTag("MonsterBullet") && gameObject.transform.eulerAngles.z != 0)
            transform.LookAt(Scrpt.Instance.transform.position);
        StartCoroutine(destory());
        StartCoroutine(des());
        StartCoroutine(sinhocheck());
        StartCoroutine(targetcheck());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Tab) && !Bos.Instance.gameObject.activeSelf)
        {
            if (GameManager.Instance.Saveposition != "없음" && gameObject.CompareTag("PlayerBullet"))
            {
                target = GameObject.Find(GameManager.Instance.Saveposition);
                transform.LookAt(target.transform);
                //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.fixedDeltaTime * 15);
                transform.position += transform.forward * speed * Time.deltaTime;

            }
        }
        else if (GameManager.Instance.Saveposition == "없음" && gameObject.CompareTag("PlayerBullet") || Input.GetKeyUp(KeyCode.Tab))
            transform.position += Scrpt.Instance.transform.forward * speed * Time.deltaTime;
        if (gameObject.CompareTag("MonsterBullet") || gameObject.CompareTag("BossBullet"))
            transform.position += transform.forward * speed * Time.deltaTime;
        if(target != null && target.transform.position.z < -10)
        {
            target = null;
        }
    }
    IEnumerator destory()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
    IEnumerator des()
    {
        yield return new WaitUntil(() => transform.position.z < -10 && gameObject.CompareTag("MonsterBullet"));
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("PlayerBullet") && other.CompareTag("Monster"))
        { Destroy(gameObject); sinho = "감지"; }
    }
    IEnumerator sinhocheck()
    {
        yield return new WaitForSeconds(3);
        if (sinho != "감지")
            Destroy(gameObject);
    }
    IEnumerator targetcheck()
    {
        yield return new WaitUntil(() => target != null);
        yield return new WaitUntil(() => target == null);
        Destroy(gameObject);
    }
}

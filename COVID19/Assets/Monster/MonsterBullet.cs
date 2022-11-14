using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterBullet : MonoBehaviour
{
    public GameObject prefab2;
    float speed = 2;
    MonsterManager manager = new MonsterManager();
    float angle;
    Rigidbody2D rid;
    private void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        Vector3 direction = Player.Instance.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle + 90);
        
    }
    private void Update()
    {
        rid.velocity = Vector3.zero;
    }


    public IEnumerator Fire2()
    {

        for (float i = 0; i < 5f; i += Time.deltaTime)
        {
            transform.Translate(new Vector3(0, -2, 0) * speed * Time.deltaTime);
            yield return null;
        }
        ObjectPool.Instance.ReturnObject(prefab2);


    }
    //아 섹스하고 싶다
    private void OnEnable()
    {
        StartCoroutine(Fire2());
    }
}

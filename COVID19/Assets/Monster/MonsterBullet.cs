using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        

    }
    private void Update()
    {
        rid.velocity = Vector3.zero;
    }


    public IEnumerator Fire2()
    {
        yield return null;
        LookPlayer();
        for (float i = 0; i < 5f; i += Time.deltaTime)
        {
            transform.Translate(new Vector3(0, -2, 0) * speed * Time.deltaTime);
            yield return null;
        }
        objectpool.Instance.ReturnObject(prefab2);


    }
    
    private void OnEnable()
    {   //ObjectPool스크립트에서 OnEnable의 시작지점 을 알아야함
        
            StartCoroutine(Fire2());
    }

    private void LookPlayer()
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
            if (!gameObject.CompareTag("BossBullet"))
        {
            Vector3 direction = Player.Instance.transform.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + 90);
        }
    }
}

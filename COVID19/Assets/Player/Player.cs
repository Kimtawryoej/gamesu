using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance; // 
    public ISTATe CurrentState;
    public Vector3 position;
    public Quaternion quaternion;
    public GameObject prefab;
    public float speed = 3;
    public float Xmax, Xmin, Ymax, Ymin;
    

    void Start()
    {

        Instance = this;
        Change(new Idle());
        position = new Vector3(transform.position.x, transform.position.y, 0);
        quaternion = transform.rotation;
    }

    void Update()
    {

        CurrentState.Update();
        float x = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        float y = Mathf.Clamp(transform.position.y, Ymin, Ymax);
        transform.position = new Vector3(x, y, transform.position.z);


        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;

        if (Public.Instance.hp <= 0)
        {
            gameObject.SetActive(false);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet2")) //왜 gameObject를 쓰는지 꼭 이해!!
        {
            Public.Instance.hp -= 1;
        }

        if (collision.gameObject.CompareTag("BossBullet")) //왜 gameObject를 쓰는지 꼭 이해!!
        {
            Public.Instance.hp -= 2;
        }
    }

    public void Change(ISTATe chan)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }

        CurrentState = chan;

        CurrentState.OnEnter(this);

    }

}

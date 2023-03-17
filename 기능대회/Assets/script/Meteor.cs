using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody;
    public bool DESTORY;
    public static Meteor Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(speed());
        StartCoroutine(stop());
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if ((TriggerManager.instance.MonsterHp[GameObject.FindWithTag("meteor")] <= 0))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator stop()
    {
        yield return new WaitUntil(() => transform.position.y <= -4.36f);
        Destroy(gameObject);
    }
    IEnumerator speed()
    {
        DESTORY = true;
        m_Rigidbody.gravityScale = 0;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(5);
        DESTORY = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        m_Rigidbody.gravityScale = 1;
    }
   
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public LayerMask layerMask;
    public static Boom instance;
    float t;
    bool Bool = true;
    Vector3 v;
    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(Bool)
        {
            transform.position = Player.Instance.transform.position + new Vector3(0, 5, 0);
            Bool = false;
        }


    }
    private void OnEnable()
    {
        StartCoroutine(stop());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerManager.instance.OnTriggerEnter2D(collision);
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(2);
        transform.position = Player.Instance.transform.position;
        t = 0;
        Bool = true;
        gameObject.SetActive(false);

    }
}
